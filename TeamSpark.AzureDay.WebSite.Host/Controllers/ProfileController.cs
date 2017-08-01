using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;
using Kaznachey.KaznacheyPayment;
using TeamSpark.AzureDay.WebSite.App;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.App.Service;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data.Enum;
using TeamSpark.AzureDay.WebSite.Host.Filter;
using TeamSpark.AzureDay.WebSite.Host.Models.Home;
using TeamSpark.AzureDay.WebSite.Host.Models.Profile;
using TeamSpark.AzureDay.WebSite.Notification;
using TeamSpark.AzureDay.WebSite.Notification.Email.Model;

namespace TeamSpark.AzureDay.WebSite.Host.Controllers
{
	public class ProfileController : Controller
	{
		private readonly WorkshopService _workshopService = new WorkshopService();

		[System.Web.Mvc.Authorize]
		public async Task<ActionResult> My()
		{
			var email = User.Identity.Name;

			var attendeeTask = AppFactory.AttendeeService.Value.GetAttendeeByEmailAsync(email);
			var ticketsTask = AppFactory.TicketService.Value.GetTicketsByEmailAsync(email);
			var workshopTicketsTask = AppFactory.TicketService.Value.GetWorkshopsTicketsAsync();

			await Task.WhenAll(attendeeTask, ticketsTask, workshopTicketsTask);

			var attendee = attendeeTask.Result;

			var model = new MyProfileModel
			{
				Email = attendee.EMail,
				LastName = attendee.LastName,
				FirstName = attendee.FirstName,
				Company = attendee.Company
			};

			var workshops = _workshopService.GetWorkshops().ToList();

			model.Workshops = new List<WorkshopEntityModel>();

			var workshopTickets = workshopTicketsTask.Result;

			foreach (var workshop in workshops)
			{
				var ticketsLeft = workshop.MaxTickets - workshopTickets.Count(x => x.WorkshopId == workshop.Id);
				if (ticketsLeft < 0)
				{
					ticketsLeft = 0;
				}

				if (ticketsLeft > 0)
				{
					model.Workshops.Add(new WorkshopEntityModel
					{
						Workshop = workshop,
						TicketsLeft = ticketsLeft
					});
				}
			}

			var tickets = ticketsTask.Result;

			if (tickets != null && tickets.Any())
			{
				model.PayedConferenceTicket = tickets.SingleOrDefault(x => x.TicketType == TicketType.Regular);

				model.PayedWorkshopTicket = tickets.SingleOrDefault(x => x.TicketType == TicketType.Workshop);
				if (model.PayedWorkshopTicket != null)
				{
					model.PayedWorkshop = _workshopService.GetWorkshop(model.PayedWorkshopTicket.WorkshopId.Value);
				}
			}

			return View(model);
		}

		[System.Web.Mvc.Authorize]
		[System.Web.Mvc.HttpPost]
		public async Task<ActionResult> My(MyProfileModel model)
		{
			var email = User.Identity.Name;
			var attendee = await AppFactory.AttendeeService.Value.GetAttendeeByEmailAsync(email);

			attendee.EMail = email;
			attendee.LastName = model.LastName;
			attendee.FirstName = model.FirstName;
			attendee.Company = model.Company;

			if (!string.IsNullOrEmpty(model.Password))
			{
				var salt = AppFactory.AttendeeService.Value.GenerateSalt();
				var passwordHash = AppFactory.AttendeeService.Value.Hash(model.Password, salt);

				attendee.Salt = salt;
				attendee.PasswordHash = passwordHash;
			}

			await AppFactory.AttendeeService.Value.UpdateProfileAsync(attendee);

			return RedirectToAction("My");
		}

		[NonAuthorize]
		public ActionResult Registration()
		{
			return View(new RegistrationModel());
		}

		[NonAuthorize]
		[System.Web.Mvc.HttpPost]
		public async Task<ActionResult> Registration(RegistrationModel model)
		{
			var attendeeExisted = await AppFactory.AttendeeService.Value.GetAttendeeByEmailAsync(model.Email);
			if (attendeeExisted != null)
			{
				model.ErrorMessage = "Пользователь с таким адресом электронной почты уже есть в системе. Если вы забыли пароль, то воспользуйтесь функцией восстановления пароля на странице входа в личный кабинет.";

				model.Password = string.Empty;
				return View(model);
			}

			var salt = AppFactory.AttendeeService.Value.GenerateSalt();
			var passwordHash = AppFactory.AttendeeService.Value.Hash(model.Password, salt);

			var attendee = new Attendee
			{
				EMail = model.Email,
				FirstName = model.FirstName,
				LastName = model.LastName,
				Company = model.Company,
				Salt = salt,
				PasswordHash = passwordHash
			};
			
			await AppFactory.AttendeeService.Value.RegisterAsync(attendee);

			return RedirectToAction("ConfirmRegistration");
		}

		[NonAuthorize]
		public async Task<ActionResult> ConfirmRegistration(string token)
		{
			if (string.IsNullOrEmpty(token))
			{
				return View("ConfirmEmail");
			}

			var authToken = await AppFactory.QuickAuthTokenService.Value.GetQuickAuthTokenByValueAsync(token, false);

			if (authToken == null)
			{
				return Redirect("~/");
			}

			await AppFactory.AttendeeService.Value.ConfirmRegistrationByTokenAsync(token);

			return View("ConfirmRegistration");
		}

		[NonAuthorize]
		public ActionResult LogIn()
		{
			var model = new LoginModel();
			return View(model);
		}

		[NonAuthorize]
		[System.Web.Mvc.HttpPost]
		public async Task<ActionResult> LogIn(LoginModel model)
		{
			var attendee = await AppFactory.AttendeeService.Value.GetAttendeeByEmailAsync(model.Email);

			if (attendee == null)
			{
				model.Password = string.Empty;
				model.ErrorMessage = "Неверный email или пароль";
				return View(model);
			}

			if (attendee.IsConfirmed && AppFactory.AttendeeService.Value.IsPasswordValid(attendee, model.Password))
			{
				FormsAuthentication.SetAuthCookie(attendee.EMail, true);
				var url = FormsAuthentication.GetRedirectUrl(attendee.EMail, true);
				return Redirect(url);
			}
			else
			{
				model.Password = string.Empty;
				model.ErrorMessage = "Неверный email или пароль";
				return View(model);
			}
		}

		[System.Web.Mvc.Authorize]
		public ActionResult LogOut()
		{
			FormsAuthentication.SignOut();
			return Redirect("~/");
		}

		private PayFormModel GetPaymentForm(List<Ticket> tickets)
		{
			if (tickets == null)
			{
				throw new ArgumentNullException(nameof(tickets));
			}

			if (!tickets.Any())
			{
				throw new ArgumentException(nameof(tickets));
			}

			KaznacheyPaymentSystem kaznachey;
			int paySystemId;
			if (string.IsNullOrEmpty(tickets[0].PaymentType))
			{
				kaznachey = new KaznacheyPaymentSystem(Configuration.KaznacheyMerchantId, Configuration.KaznacheyMerchantSecreet);
				paySystemId = kaznachey.GetMerchantInformation().PaySystems[0].Id;
			}
			else
			{
				switch (tickets[0].PaymentType.ToLowerInvariant())
				{
					case "kaznachey":
						kaznachey = new KaznacheyPaymentSystem(Configuration.KaznacheyMerchantId, Configuration.KaznacheyMerchantSecreet);
						paySystemId = kaznachey.GetMerchantInformation().PaySystems[0].Id;
						break;
					case "liqpay":
						kaznachey = new KaznacheyPaymentSystem(Configuration.KaznacheyMerchantId, Configuration.KaznacheyMerchantSecreet);
						paySystemId = kaznachey.GetMerchantInformation().PaySystems[3].Id;
						break;
					default:
						kaznachey = new KaznacheyPaymentSystem(Configuration.KaznacheyMerchantId, Configuration.KaznacheyMerchantSecreet);
						paySystemId = kaznachey.GetMerchantInformation().PaySystems[0].Id;
						break;
				}
			}

			var paymentRequest = new PaymentRequest(paySystemId);
			paymentRequest.Language = "RU";
			paymentRequest.Currency = "UAH";
			paymentRequest.PaymentDetail = new PaymentDetails
			{
				EMail = tickets[0].Attendee.EMail,
				MerchantInternalUserId = tickets[0].Attendee.EMail,
				MerchantInternalPaymentId = $"{tickets[0].Attendee.EMail}-{string.Join("|", tickets.Select(x => x.TicketType.ToString()))}",
				BuyerFirstname = tickets[0].Attendee.FirstName,
				BuyerLastname = tickets[0].Attendee.LastName,
				ReturnUrl = $"{Configuration.Host}/profile/my",
				StatusUrl = $"{Configuration.Host}/api/tickets/paymentconfirm"
			};
			paymentRequest.Products = new List<Product>
			{
				new Product
				{
					ProductId = string.Join("|", tickets.Select(x => x.TicketType.ToString())),
					ProductItemsNum = 1,
					ProductName = $"{tickets[0].Attendee.FirstName} {tickets[0].Attendee.LastName} билет на AzureDay {Configuration.Year} ({string.Join("|", tickets.Select(x => x.TicketType.ToString()))})",
					ProductPrice = (decimal) tickets.Sum(x => x.Price)
				}
			};

			var form = kaznachey.CreatePayment(paymentRequest).ExternalFormHtml;

			var model = new PayFormModel
			{
				Form = form
			};
			return model;
		}

		[System.Web.Mvc.Authorize]
		[System.Web.Mvc.HttpPost]
		public async Task<ActionResult> Pay([FromBody]PayModel model)
		{
			if (!model.HasConferenceTicket && (!model.HasWorkshopTicket || model.DdlWorkshop == 0))
			{
				throw new ArgumentException(nameof(model));
			}

			var tickets = new List<Ticket>();

			if (model.HasConferenceTicket)
			{
				tickets.Add(new Ticket
				{
					TicketType = TicketType.Regular,
					PaymentType = model.PaymentType,
					Price = (double)AppFactory.TicketService.Value.GetTicketPrice(TicketType.Regular)
				});
			}

			if (model.HasWorkshopTicket && model.DdlWorkshop > 0)
			{
				tickets.Add(new Ticket
				{
					TicketType = TicketType.Workshop,
					PaymentType = model.PaymentType,
					WorkshopId = model.DdlWorkshop,
					Price = (double)AppFactory.TicketService.Value.GetTicketPrice(TicketType.Workshop)
				});
			}

			if (!tickets.Any())
			{
				throw new ArgumentException(nameof(model));
			}

			var coupon = await AppFactory.CouponService.Value.GetValidCouponByCodeAsync(model.PromoCode);

			decimal ticketTotalPrice = tickets.Count > 1 ?
				AppFactory.TicketService.Value.GetTicketPrice(TicketType.Regular | TicketType.Workshop) :
				AppFactory.TicketService.Value.GetTicketPrice(tickets[0].TicketType);
			ticketTotalPrice = AppFactory.CouponService.Value.GetPriceWithCoupon(ticketTotalPrice, coupon);

			await AppFactory.CouponService.Value.UseCouponByCodeAsync(model.PromoCode);

			if (tickets.Count > 1)
			{
				tickets[0].Price = (double)ticketTotalPrice / 2;
				tickets[0].Coupon = coupon;
				tickets[0].IsPayed = tickets[0].Price <= 0;

				tickets[1].Price = (double)ticketTotalPrice / 2;
				tickets[1].Coupon = coupon;
				tickets[1].IsPayed = tickets[1].Price <= 0;
			}
			else
			{
				tickets[0].Price = (double) ticketTotalPrice;
				tickets[0].Coupon = coupon;
				tickets[0].IsPayed = tickets[0].Price <= 0;
			}

			var isPayed = true;

			foreach (var ticket in tickets)
			{
				if (ticket.Attendee == null)
				{
					var email = User.Identity.Name;
					ticket.Attendee = await AppFactory.AttendeeService.Value.GetAttendeeByEmailAsync(email);
				}

				await AppFactory.TicketService.Value.AddTicketAsync(ticket);

				isPayed = isPayed && ticket.IsPayed;
			}

			if (isPayed)
			{
				return RedirectToAction("My");
			}
			else
			{
				var payForm = GetPaymentForm(tickets);

				return View("PayForm", payForm);
			}
		}

		[System.Web.Mvc.Authorize]
		public async Task<ActionResult> PayAgain()
		{
			var email = User.Identity.Name;

			var attendee = await AppFactory.AttendeeService.Value.GetAttendeeByEmailAsync(email);
			var tickets = await AppFactory.TicketService.Value.GetTicketsByEmailAsync(email);

			foreach (var ticket in tickets)
			{
				ticket.Attendee = attendee;
			}

			var model = GetPaymentForm(tickets);

			return View("PayForm", model);
		}

		[System.Web.Mvc.Authorize]
		public async Task<ActionResult> DeleteTicket(string token)
		{
			var email = User.Identity.Name;
			TicketType ticketType;
			if (!Enum.TryParse(token, true, out ticketType))
			{
				throw new ArgumentException();
			}

			var tickets = await AppFactory.TicketService.Value.GetTicketsByEmailAsync(email);
			var ticketToDelete = tickets.Single(x => x.TicketType == ticketType);
			var ticketToRemain = tickets.SingleOrDefault(x => x.TicketType != ticketType);

			var couponCode = ticketToDelete.Coupon == null ?
				string.Empty :
				ticketToDelete.Coupon.Code;

			var tasks = new List<Task>
			{
				AppFactory.TicketService.Value.DeleteTicketAsync(email, ticketToDelete.TicketType)
			};

			if (ticketToRemain == null)
			{
				tasks.Add(AppFactory.CouponService.Value.RestoreCouponByCodeAsync(couponCode));
			}
			else
			{
				var price = AppFactory.TicketService.Value.GetTicketPrice(ticketToRemain.TicketType);

				if (ticketToRemain.Coupon != null)
				{
					price = AppFactory.CouponService.Value.GetPriceWithCoupon(price, ticketToRemain.Coupon);
				}

				tasks.Add(AppFactory.TicketService.Value.UpdateTicketPriceAsync(email, ticketToRemain.TicketType, price));
			}

			await Task.WhenAll(tasks);

			return RedirectToAction("My");
		}

		[NonAuthorize]
		[System.Web.Mvc.HttpPost]
		public async Task<ActionResult> RestorePassword(LoginModel model)
		{
			var user = await AppFactory.AttendeeService.Value.GetAttendeeByEmailAsync(model.Email);

			if (user != null)
			{
				var token = new QuickAuthToken
				{
					Email = user.EMail,
					Token = Guid.NewGuid().ToString("N")
				};

				var notification = new RestorePasswordMessage
				{
					Email = user.EMail,
					FullName = user.FullName,
					Token = token.Token
				};

				await Task.WhenAll(
					AppFactory.QuickAuthTokenService.Value.AddQuickAuthTokenAsync(token),
					NotificationFactory.AttendeeNotificationService.Value.SendRestorePasswordEmailAsync(notification)
				);
			}

			return View();
		}

		//[Authorize]
		//public ActionResult Quiz()
		//{
		//	return View();
		//}

		//[Authorize]
		//public ActionResult Feedback()
		//{
		//	return View();
		//}
	}
}