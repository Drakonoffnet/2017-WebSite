using System.Collections.Generic;
using System.Linq;
using TeamSpark.AzureDay.WebSite.App.Entity;

namespace TeamSpark.AzureDay.WebSite.App.Service
{
	public sealed class WorkshopService
	{
		private readonly LanguageService _languageService = new LanguageService();
		private readonly SpeakerService _speakerService = new SpeakerService();
		private readonly RoomService _roomService = new RoomService();

		private readonly List<Workshop> _workshops = new List<Workshop>();

		public WorkshopService()
		{
			_workshops = new List<Workshop>
			{
				new Workshop
				{
					Id = 1,
					Language = _languageService.English,
					Room = _roomService.Workshop1,
					Speaker = _speakerService.MMartensson(),
					Title = Localization.App.Service.Workshops.MMartensson_01.Title,
					Description = Localization.App.Service.Workshops.MMartensson_01.Description
				},
				new Workshop
				{
					Id = 2,
					Language = _languageService.Russian,
					Room = _roomService.Workshop2,
					Speaker = _speakerService.DIvanov(),
					Title = Localization.App.Service.Workshops.DIvanov_01.Title,
					Description = Localization.App.Service.Workshops.DIvanov_01.Description
				},
				new Workshop
				{
					Id = 3,
					Language = _languageService.Russian,
					Room = _roomService.Workshop3,
					Speaker = _speakerService.EPolonychko(),
					Title = Localization.App.Service.Workshops.EPolonychko_02.Title,
					Description = Localization.App.Service.Workshops.EPolonychko_02.Description
				},
				new Workshop
				{
					Id = 4,
					Language = _languageService.Russian,
					Room = _roomService.Workshop4,
					Speaker = _speakerService.ILeontiev(),
					Title = Localization.App.Service.Workshops.ILeontiev_01.Title,
					Description = Localization.App.Service.Workshops.ILeontiev_01.Description
				},
				new Workshop
				{
					Id = 5,
					Language = _languageService.Russian,
					Room = _roomService.Workshop5,
					Speaker = _speakerService.ASurkov(),
					Title = Localization.App.Service.Workshops.ASurkov_01.Title,
					Description = Localization.App.Service.Workshops.ASurkov_01.Description
				},
				new Workshop
				{
					Id = 6,
					Language = _languageService.Russian,
					Room = _roomService.Workshop6,
					Speaker = _speakerService.IReznykov(),
					Title = Localization.App.Service.Workshops.IReznykov_01.Title,
					Description = Localization.App.Service.Workshops.IReznykov_01.Description
				},
				new Workshop
				{
					Id = 7,
					Language = _languageService.Russian,
					Room = _roomService.Workshop7,
					Speaker = _speakerService.ADeren(),
					Title = Localization.App.Service.Workshops.ADeren_01.Title,
					Description = Localization.App.Service.Workshops.ADeren_01.Description
				},
				new Workshop
				{
					Id = 8,
					Language = _languageService.Russian,
					Room = _roomService.Workshop8,
					Speaker = _speakerService.SPoplavskiy(),
					Title = Localization.App.Service.Workshops.SPoplavskiy_02.Title,
					Description = Localization.App.Service.Workshops.SPoplavskiy_02.Description
				}
			};
		}

		public IEnumerable<Workshop> GetWorkshops()
		{
			return _workshops;
		}

		public Workshop MMartensson_01 { get { return _workshops.Single(x => x.Id == 1); } }
		public Workshop DIvanov_01 { get { return _workshops.Single(x => x.Id == 2); } }
		public Workshop EPolonychko_02 { get { return _workshops.Single(x => x.Id == 3); } }
		public Workshop ILeontiev_01 { get { return _workshops.Single(x => x.Id == 4); } }
		public Workshop ASurkov_01 { get { return _workshops.Single(x => x.Id == 5); } }
		public Workshop IReznykov_01 { get { return _workshops.Single(x => x.Id == 6); } }
		public Workshop ADeren_01 { get { return _workshops.Single(x => x.Id == 7); } }
		public Workshop SPoplavskiy_02 { get { return _workshops.Single(x => x.Id == 8); } }
	}
}
