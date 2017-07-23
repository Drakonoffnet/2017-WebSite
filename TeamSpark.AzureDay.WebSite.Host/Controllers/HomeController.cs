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
		public async Task<ActionResult> Index()
		{
			var model = new IndexModel
			{
				Speakers = new SpeakersModel
				{
					SpeakersCollections = new List<List<Speaker>>()
				},
				Partners = new PartnersModel
				{
					PartnersCollection = new Dictionary<PartnerType, List<Partner>>()
				}
			};

			var speakers = new SpeakerService().GetSpeakers();
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

			var partners = new PartnerService().GetPartners();
			model.Partners.PartnersCollection = partners
				.GroupBy(p => p.PartnerType)
				.ToDictionary(p => p.Key, group => group.OrderBy(p => p.OrderN).ToList());

			return View(model);
		}

		public async Task<ActionResult> Schedule()
		{
			var model = new ScheduleModel();

			model.Rooms = new RoomService().GetRooms().ToList();

			model.Timetables = new TimetableService().GetTimetable()
				.GroupBy(
					t => t.TimeStart,
					(key, timetables) => timetables.OrderBy(t => t.Room.ColorNumber).ToList())
				.ToList();

			return View(model);
		}

		public async Task<ActionResult> Partners()
		{
			var model = new PartnersModel();

			model.PartnersCollection = new PartnerService().GetPartners()
				.GroupBy(p => p.PartnerType)
				.ToDictionary(p => p.Key, group => group.OrderBy(p => p.OrderN).ToList());

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