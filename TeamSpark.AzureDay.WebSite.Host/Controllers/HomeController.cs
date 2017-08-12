using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;
using TeamSpark.AzureDay.WebSite.App;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.App.Service;
using TeamSpark.AzureDay.WebSite.Data.Enum;
using TeamSpark.AzureDay.WebSite.Host.Filter;
using TeamSpark.AzureDay.WebSite.Host.Models.Home;

namespace TeamSpark.AzureDay.WebSite.Host.Controllers
{
	public class HomeController : Controller
	{
		private readonly Lazy<PartnerService> _partnerService = new Lazy<PartnerService>(() => new PartnerService());
		private readonly Lazy<SpeakerService> _speakerService = new Lazy<SpeakerService>(() => new SpeakerService());
		private readonly Lazy<RoomService> _roomService = new Lazy<RoomService>(() => new RoomService());
		private readonly Lazy<TimetableService> _timetableService = new Lazy<TimetableService>(() => new TimetableService());
		private readonly Lazy<WorkshopService> _workshopService = new Lazy<WorkshopService>(() => new WorkshopService());
		private readonly Lazy<TopicService> _topicService = new Lazy<TopicService>(() => new TopicService());

		public async Task<ActionResult> Index()
		{
			var model = new IndexModel
			{
				Speakers = new SpeakersModel
				{
					SpeakersCollections = new List<List<Speaker>>()
				},
				Partners = _partnerService.Value.GetPartners().ToList()
			};

			var speakers = _speakerService.Value.GetSpeakers();
			var i = 0;
			foreach (var speaker in speakers)
			{
				List<Speaker> list;
				if (i == 0)
				{
					list = new List<Speaker>();
					model.Speakers.SpeakersCollections.Add(list);
				}
				else
				{
					list = model.Speakers.SpeakersCollections.Last();
				}

				list.Add(speaker);

				if (i == 3)
				{
					i = 0;
				}
				else
				{
					i++;
				}
			}

			return View(model);
		}

		public async Task<ActionResult> Schedule()
		{
			var model = new ScheduleModel();

			model.Rooms = _roomService.Value
				.GetRooms()
				.Where(x => x.RoomType == RoomType.LectureRoom)
				.ToList();

			model.Timetables = _timetableService.Value
				.GetTimetable()
				.GroupBy(
					t => t.TimeStart,
					(key, timetables) => timetables.OrderBy(t => t.Room.ColorNumber).ToList())
				.ToList();

			return View(model);
		}

        public async Task<ActionResult> Workshops()
		{
			var model = new WorkshopsModel
			{
				Workshops = new List<WorkshopEntityModel>()
			};

			var workshops = _workshopService.Value.GetWorkshops().ToList();
			var workshopTickets = await AppFactory.TicketService.Value.GetWorkshopsTicketsAsync();

			foreach (var workshop in workshops)
			{
				var ticketsLeft = workshop.MaxTickets - workshopTickets.Count(x => x.WorkshopId == workshop.Id);
				if (ticketsLeft < 0)
				{
					ticketsLeft = 0;
				}

				model.Workshops.Add(new WorkshopEntityModel
				{
					Workshop = workshop,
					TicketsLeft = ticketsLeft,
					ShowSpeakerInfo = true
				});
			}

			return View(model);
		}

		public async Task<ActionResult> WorkshopEntity(int id)
		{
			var model = new WorkshopEntityModel
			{
				ShowSpeakerInfo = true
			};

			model.Workshop = _workshopService.Value
				.GetWorkshop(id);

			if (model.Workshop == null)
			{
				return RedirectToAction("Workshops");
			}

			model.TicketsLeft = model.Workshop.MaxTickets - (await AppFactory.TicketService.Value.GetWorkshopTicketsAsync(id)).Count;
			if (model.TicketsLeft < 0)
			{
				model.TicketsLeft = 0;
			}

			return View(model);
		}

		public async Task<ActionResult> Speakers()
		{
			var model = new SpeakersModel
			{
				SpeakersCollections = new List<List<Speaker>>()
			};

			var speakers = _speakerService.Value.GetSpeakers();
			var i = 0;
			foreach (var speaker in speakers)
			{
				List<Speaker> list;
				if (i == 0)
				{
					list = new List<Speaker>();
					model.SpeakersCollections.Add(list);
				}
				else
				{
					list = model.SpeakersCollections.Last();
				}

				list.Add(speaker);

				if (i == 3)
				{
					i = 0;
				}
				else
				{
					i++;
				}
			}

			return View(model);
		}

		public async Task<ActionResult> SpeakerEntity(string id)
		{
			var model = new SpeakerEntityModel();

			model.Speaker = _speakerService.Value.GetSpeaker(id);

			if (model.Speaker == null)
			{
				return RedirectToAction("Index");
			}

			var workshops = _workshopService.Value
				.GetWorkshops()
				.Where(x => x.Speaker.Id.Equals(model.Speaker.Id, StringComparison.InvariantCultureIgnoreCase))
				.ToList();

			model.Workshops = new List<WorkshopEntityModel>();

			foreach (var workshop in workshops)
			{
				var ticketsLeft = workshop.MaxTickets - (await AppFactory.TicketService.Value.GetWorkshopTicketsAsync(workshop.Id)).Count;
				if (ticketsLeft < 0)
				{
					ticketsLeft = 0;
				}

				model.Workshops.Add(new WorkshopEntityModel
				{
					Workshop = workshop,
					TicketsLeft = ticketsLeft,
					ShowSpeakerInfo = false
				});
			}

			model.Topics = _topicService.Value
				.GetTopics()
				.Where(x => x.Speakers.Select(x1 => x1.Id).Any(x2 => x2.Equals(model.Speaker.Id, StringComparison.InvariantCultureIgnoreCase)))
				.OrderBy(x => x.Timetable.TimeStart)
				.ToList();

			return View(model);
		}

		public async Task<ActionResult> Partners()
		{
			var model = new PartnersModel();

			model.PartnersCollection = new Dictionary<PartnerType, List<Partner>>();

			foreach (var partnerType in Enum.GetValues(typeof(PartnerType)))
			{
				var partners = _partnerService.Value.GetPartnersByType((PartnerType)partnerType).ToList();
				model.PartnersCollection.Add((PartnerType)partnerType, partners);
			}

			return View(model);
		}

		[NonAuthorize]
		public async Task<ActionResult> Redirect([FromUri] string quickAuthToken, [FromUri] string redirectUrl)
		{
			var authToken = await AppFactory.QuickAuthTokenService.Value.GetQuickAuthTokenByValueAsync(quickAuthToken, false);

			if (authToken != null)
			{
				var attendee = await AppFactory.AttendeeService.Value.GetAttendeeByEmailAsync(authToken.Email);
				if (attendee != null && attendee.IsConfirmed)
				{
					FormsAuthentication.SetAuthCookie(attendee.EMail, true);
					await AppFactory.QuickAuthTokenService.Value.ExpireTokenByValueAsync(quickAuthToken);
				}
			}

			return Redirect(redirectUrl);
		}
	}
}