using System;
using System.Collections.Generic;
using System.Linq;
using TeamSpark.AzureDay.WebSite.App.Entity;

namespace TeamSpark.AzureDay.WebSite.App.Service
{
	public sealed class SpeakerService
	{
		private readonly List<Speaker> _speakers = new List<Speaker>();
		private readonly CountryService _countryService = new CountryService();

		public SpeakerService()
		{
			_speakers.Add(ABoyko());
			//_speakers.Add(MMartensson());
			_speakers.Add(OKrakovetskyi());
			_speakers.Add(DReznik());
			_speakers.Add(ALaysha());

			_speakers.Add(IFesenko());
			_speakers.Add(OChorny());
			_speakers.Add(DDurasau());
			_speakers.Add(ASurkov());

			_speakers.Add(EPolonychko());
			_speakers.Add(SKorzh());
			_speakers.Add(ILeontiev());
			_speakers.Add(SKryshtop());

			_speakers.Add(DIvanov());
			_speakers.Add(IReznykov());
			_speakers.Add(VThavonekham());
			_speakers.Add(MSmereczynski());

			_speakers.Add(ADeren());
			_speakers.Add(SPoplavskiy());
			_speakers.Add(AYurchenko());
			_speakers.Add(VRadchuk());

			_speakers.Add(ATkachenko());
		}

		public IEnumerable<Speaker> GetSpeakers()
		{
			return _speakers;
		}

		public Speaker GetSpeaker(string id)
		{
			return _speakers.SingleOrDefault(x => x.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase));
		}

		public Speaker ABoyko()
		{
			return new Speaker
			{
				Id = "ABoyko",
				FirstName = Localization.App.Service.Speaker.ABoyko.FirstName,
				LastName = Localization.App.Service.Speaker.ABoyko.LastName,
				Bio = Localization.App.Service.Speaker.ABoyko.Bio.Replace(Environment.NewLine, "<br/>"),
				Country = _countryService.Ukraine,
				PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/ABoyko.jpg",
				FacebookUrl = "https://www.facebook.com/boyko.ant",
				GitHubUrl = "",
				GoogleUrl = "",
				LinkedInUrl = "https://www.linkedin.com/in/boykoant/",
				MsdnUrl = "",
				MvpUrl = "https://mvp.microsoft.com/en-us/PublicProfile/5000824",
				TwitterUrl = "https://twitter.com/BoykoAnt",
				YouTubeUrl = "",
				WebUrl = "",
				CompanyName = "Ciklum",
				JobTitle = "Solution Architect"
			};
		}

		public Speaker ALaysha()
		{
			return new Speaker
			{
				Id = "ALaysha",
				FirstName = Localization.App.Service.Speaker.ALaysha.FirstName,
				LastName = Localization.App.Service.Speaker.ALaysha.LastName,
				Bio = Localization.App.Service.Speaker.ALaysha.Bio.Replace(Environment.NewLine, "<br/>"),
				Country = _countryService.Belarus,
				PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/ALaysha.jpg",
				FacebookUrl = "https://www.facebook.com/alexander.laysha",
				GitHubUrl = "",
				GoogleUrl = "",
				LinkedInUrl = "",
				MsdnUrl = "",
				MvpUrl = "",
				TwitterUrl = "https://twitter.com/layshaalexander",
				YouTubeUrl = "",
				WebUrl = "",
				CompanyName = "EPAM",
				JobTitle = "Solution Architect"
			};
		}

		public Speaker OChorny()
		{
			return new Speaker
			{
				Id = "OChorny",
				FirstName = Localization.App.Service.Speaker.OChorny.FirstName,
				LastName = Localization.App.Service.Speaker.OChorny.LastName,
				Bio = Localization.App.Service.Speaker.OChorny.Bio.Replace(Environment.NewLine, "<br/>"),
				Country = _countryService.Ukraine,
				PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/_Person.png",
				FacebookUrl = "",
				GitHubUrl = "",
				GoogleUrl = "",
				LinkedInUrl = "",
				MsdnUrl = "",
				MvpUrl = "",
				TwitterUrl = "",
				YouTubeUrl = "",
				WebUrl = "",
				CompanyName = "Ciklum",
				JobTitle = ""
			};
		}

		public Speaker DDurasau()
		{
			return new Speaker
			{
				Id = "DDurasau",
				FirstName = Localization.App.Service.Speaker.DDurasau.FirstName,
				LastName = Localization.App.Service.Speaker.DDurasau.LastName,
				Bio = Localization.App.Service.Speaker.DDurasau.Bio.Replace(Environment.NewLine, "<br/>"),
				Country = _countryService.Belarus,
				PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/DDurasau.jpg",
				FacebookUrl = "",
				GitHubUrl = "",
				GoogleUrl = "",
				LinkedInUrl = "",
				MsdnUrl = "",
				MvpUrl = "",
				TwitterUrl = "",
				YouTubeUrl = "",
				WebUrl = "",
				CompanyName = "EPAM Systems",
				JobTitle = "Solution Architect"
			};
		}

		public Speaker IFesenko()
		{
			return new Speaker
			{
				Id = "IFesenko",
				FirstName = Localization.App.Service.Speaker.IFesenko.FirstName,
				LastName = Localization.App.Service.Speaker.IFesenko.LastName,
				Bio = Localization.App.Service.Speaker.IFesenko.Bio.Replace(Environment.NewLine, "<br/>"),
				Country = _countryService.Ukraine,
				PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/IFesenko.jpg",
				FacebookUrl = "",
				GitHubUrl = "https://github.com/Ky7m",
				GoogleUrl = "",
				LinkedInUrl = "https://www.linkedin.com/in/ifesen",
				MsdnUrl = "",
				MvpUrl = "",
				TwitterUrl = "https://twitter.com/Ky7m",
				YouTubeUrl = "",
				WebUrl = "https://www.ifesenko.com/",
				CompanyName = "SoftServe Inc.",
				JobTitle = "Application Architect"
			};
		}

		public Speaker DIvanov()
		{
			return new Speaker
			{
				Id = "DIvanov",
				FirstName = Localization.App.Service.Speaker.DIvanov.FirstName,
				LastName = Localization.App.Service.Speaker.DIvanov.LastName,
				Bio = Localization.App.Service.Speaker.DIvanov.Bio.Replace(Environment.NewLine, "<br/>"),
				Country = _countryService.Ukraine,
				PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/DIvanov.jpg",
				FacebookUrl = "",
				GitHubUrl = "",
				GoogleUrl = "",
				LinkedInUrl = "",
				MsdnUrl = "",
				MvpUrl = "",
				TwitterUrl = "",
				YouTubeUrl = "",
				WebUrl = "",
				CompanyName = "Developex",
				JobTitle = "developer"
			};
}

		public Speaker SKorzh()
		{
			return new Speaker
			{
				Id = "SKorzh",
				FirstName = Localization.App.Service.Speaker.SKorzh.FirstName,
				LastName = Localization.App.Service.Speaker.SKorzh.LastName,
				Bio = Localization.App.Service.Speaker.SKorzh.Bio.Replace(Environment.NewLine, "<br/>"),
				Country = _countryService.Ukraine,
				PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/SKorzh.jpeg",
				FacebookUrl = "https://www.facebook.com/sergiy.korzh",
				GitHubUrl = "",
				GoogleUrl = "",
				LinkedInUrl = "",
				MsdnUrl = "",
				MvpUrl = "",
				TwitterUrl = "",
				YouTubeUrl = "",
				WebUrl = "",
				CompanyName = "Korzh.com",
				JobTitle = "CEO"
			};
		}

		public Speaker SKryshtop()
		{
			return new Speaker
			{
				Id = "SKryshtop",
				FirstName = Localization.App.Service.Speaker.SKryshtop.FirstName,
				LastName = Localization.App.Service.Speaker.SKryshtop.LastName,
				Bio = Localization.App.Service.Speaker.SKryshtop.Bio.Replace(Environment.NewLine, "<br/>"),
				Country = _countryService.Ukraine,
				PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/SKryshtop01.jpg",
				FacebookUrl = "",
				GitHubUrl = "",
				GoogleUrl = "",
				LinkedInUrl = "",
				MsdnUrl = "",
				MvpUrl = "",
				TwitterUrl = "",
				YouTubeUrl = "",
				WebUrl = "",
				CompanyName = "EPAM",
				JobTitle = "Software Engineering Manager"
			};
		}

		public Speaker ILeontiev()
		{
			return new Speaker
			{
				Id = "ILeontiev",
				FirstName = Localization.App.Service.Speaker.ILeontiev.FirstName,
				LastName = Localization.App.Service.Speaker.ILeontiev.LastName,
				Bio = Localization.App.Service.Speaker.ILeontiev.Bio.Replace(Environment.NewLine, "<br/>"),
				Country = _countryService.France,
				PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/ILeontyev01.jpg",
				FacebookUrl = "",
				GitHubUrl = "",
				GoogleUrl = "",
				LinkedInUrl = "",
				MsdnUrl = "",
				MvpUrl = "",
				TwitterUrl = "",
				YouTubeUrl = "",
				WebUrl = "",
				CompanyName = "Viseo",
				JobTitle = "Azure Architect"
			};
		}

		//public Speaker MMartensson()
		//{
		//	return new Speaker
		//	{
		//		Id = 10,
		//		FirstName = Localization.App.Service.Speaker.MMartensson.FirstName,
		//		LastName = Localization.App.Service.Speaker.MMartensson.LastName,
		//		Bio = Localization.App.Service.Speaker.MMartensson.Bio.Replace(Environment.NewLine, "<br/>"),
		//		Country = _countryService.Sweden,
		//		PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/MMartensson.jpg",
		//		FacebookUrl = "https://www.facebook.com/noopman",
		//		GitHubUrl = "",
		//		GoogleUrl = "",
		//		LinkedInUrl = "https://www.linkedin.com/in/noopman",
		//		MsdnUrl = "",
		//		MvpUrl = "",
		//		TwitterUrl = "https://twitter.com/noopman",
		//		YouTubeUrl = "",
		//		WebUrl = "",
		//		CompanyName = "Loftysoft",
		//		JobTitle = "CEO"
		//	};
		//}

		public Speaker EPolonychko()
		{
			return new Speaker
			{
				Id = "EPolonychko",
				FirstName = Localization.App.Service.Speaker.EPolonychko.FirstName,
				LastName = Localization.App.Service.Speaker.EPolonychko.LastName,
				Bio = Localization.App.Service.Speaker.EPolonychko.Bio.Replace(Environment.NewLine, "<br/>"),
				Country = _countryService.Ukraine,
				PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/EPolonychko.jpg",
				FacebookUrl = "https://www.facebook.com/mydjeki",
				GitHubUrl = "",
				GoogleUrl = "",
				LinkedInUrl = "",
				MsdnUrl = "",
				MvpUrl = "",
				TwitterUrl = "",
				YouTubeUrl = "",
				WebUrl = "",
				CompanyName = "",
				JobTitle = "BI architect"
			};
		}

		public Speaker DReznik()
		{
			return new Speaker
			{
				Id = "DReznik",
				FirstName = Localization.App.Service.Speaker.DReznik.FirstName,
				LastName = Localization.App.Service.Speaker.DReznik.LastName,
				Bio = Localization.App.Service.Speaker.DReznik.Bio.Replace(Environment.NewLine, "<br/>"),
				Country = _countryService.Ukraine,
				PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/DReznik.jpg",
				FacebookUrl = "https://www.facebook.com/denis.reznik.5",
				GitHubUrl = "",
				GoogleUrl = "",
				LinkedInUrl = "",
				MsdnUrl = "",
				MvpUrl = "",
				TwitterUrl = "https://twitter.com/DenisReznik",
				YouTubeUrl = "",
				WebUrl = "",
				CompanyName = "Intapp, Inc.",
				JobTitle = "Data Architect"
			};
		}

		public Speaker IReznykov()
		{
			return new Speaker
			{
				Id = "IReznykov",
				FirstName = Localization.App.Service.Speaker.IReznykov.FirstName,
				LastName = Localization.App.Service.Speaker.IReznykov.LastName,
				Bio = Localization.App.Service.Speaker.IReznykov.Bio.Replace(Environment.NewLine, "<br/>"),
				Country = _countryService.Ukraine,
				PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/IReznykov.jpg",
				FacebookUrl = "https://www.facebook.com/ireznykov",
				GitHubUrl = "",
				GoogleUrl = "",
				LinkedInUrl = "https://www.linkedin.com/in/illya-reznykov-783a2930/",
				MsdnUrl = "",
				MvpUrl = "",
				TwitterUrl = "",
				YouTubeUrl = "",
				WebUrl = "https://ireznykov.com",
				CompanyName = "",
				JobTitle = "Private employee"
			};
		}

		public Speaker ASurkov()
		{
			return new Speaker
			{
				Id = "ASurkov",
				FirstName = Localization.App.Service.Speaker.ASurkov.FirstName,
				LastName = Localization.App.Service.Speaker.ASurkov.LastName,
				Bio = Localization.App.Service.Speaker.ASurkov.Bio.Replace(Environment.NewLine, "<br/>"),
				Country = _countryService.Russia,
				PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/ASurkov.jpg",
				FacebookUrl = "https://www.facebook.com/AOSurkov",
				GitHubUrl = "",
				GoogleUrl = "",
				LinkedInUrl = "",
				MsdnUrl = "",
				MvpUrl = "https://mvp.microsoft.com/ru-ru/PublicProfile/5002197",
				TwitterUrl = "https://twitter.com/AOSurkov",
				YouTubeUrl = "",
				WebUrl = "https://www.meetup.com/IoTCommunity/",
				CompanyName = "Inprosystem Ltd",
				JobTitle = "CTO"
			};
		}

		public Speaker VThavonekham()
		{
			return new Speaker
			{
				Id = "VThavonekham",
				FirstName = Localization.App.Service.Speaker.VThavonekham.FirstName,
				LastName = Localization.App.Service.Speaker.VThavonekham.LastName,
				Bio = Localization.App.Service.Speaker.VThavonekham.Bio.Replace(Environment.NewLine, "<br/>"),
				Country = _countryService.France,
				PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/_Person.png",
				FacebookUrl = "",
				GitHubUrl = "",
				GoogleUrl = "",
				LinkedInUrl = "",
				MsdnUrl = "",
				MvpUrl = "",
				TwitterUrl = "",
				YouTubeUrl = "",
				WebUrl = "",
				CompanyName = "VISEO",
				JobTitle = ""
			};
		}

		public Speaker MSmereczynski()
		{
			return new Speaker
			{
				Id = "MSmereczynski",
				FirstName = Localization.App.Service.Speaker.MSmereczynski.FirstName,
				LastName = Localization.App.Service.Speaker.MSmereczynski.LastName,
				Bio = Localization.App.Service.Speaker.MSmereczynski.Bio.Replace(Environment.NewLine, "<br/>"),
				Country = _countryService.Poland,
				PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/MSmereczynski.jpg",
				FacebookUrl = "",
				GitHubUrl = "",
				GoogleUrl = "",
				LinkedInUrl = "https://www.linkedin.com/in/smereczynski/",
				MsdnUrl = "",
				MvpUrl = "",
				TwitterUrl = "https://twitter.com/smereczynski",
				YouTubeUrl = "",
				WebUrl = "",
				CompanyName = "Free Media",
				JobTitle = "CEO, CTO, CFO, CMO, COO, C3PO"
			};
		}

		public Speaker ADeren()
		{
			return new Speaker
			{
				Id = "MSmereczynski",
				FirstName = Localization.App.Service.Speaker.ADeren.FirstName,
				LastName = Localization.App.Service.Speaker.ADeren.LastName,
				Bio = Localization.App.Service.Speaker.ADeren.Bio.Replace(Environment.NewLine, "<br/>"),
				Country = _countryService.Ukraine,
				PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/ADeren.jpg",
				FacebookUrl = "https://www.facebook.com/dalligieri",
				GitHubUrl = "",
				GoogleUrl = "",
				LinkedInUrl = "https://linkedin.com/in/andriy-deren-9a872029",
				MsdnUrl = "",
				MvpUrl = "",
				TwitterUrl = "https://twitter.com/dralligieri",
				YouTubeUrl = "",
				WebUrl = "",
				CompanyName = "Onlizer LLC",
				JobTitle = "CEO"
			};
		}

		public Speaker SPoplavskiy()
		{
			return new Speaker
			{
				Id = "SPoplavskiy",
				FirstName = Localization.App.Service.Speaker.SPoplavskiy.FirstName,
				LastName = Localization.App.Service.Speaker.SPoplavskiy.LastName,
				Bio = Localization.App.Service.Speaker.SPoplavskiy.Bio.Replace(Environment.NewLine, "<br/>"),
				Country = _countryService.Ukraine,
				PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/SPoplavskiy.jpg",
				FacebookUrl = "https://www.facebook.com/sergey.poplavskiy.35",
				GitHubUrl = "",
				GoogleUrl = "",
				LinkedInUrl = "",
				MsdnUrl = "",
				MvpUrl = "",
				TwitterUrl = "",
				YouTubeUrl = "",
				WebUrl = "",
				CompanyName = "Microsoft",
				JobTitle = "Commercial Software Engineer, CEE"
			};
		}

		public Speaker OKrakovetskyi()
		{
			return new Speaker
			{
				Id = "OKrakovetskyi",
				FirstName = Localization.App.Service.Speaker.OKrakovetskyi.FirstName,
				LastName = Localization.App.Service.Speaker.OKrakovetskyi.LastName,
				Bio = Localization.App.Service.Speaker.OKrakovetskyi.Bio.Replace(Environment.NewLine, "<br/>"),
				Country = _countryService.Ukraine,
				PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/OKrakovetskyi.jpg",
				FacebookUrl = "https://www.facebook.com/alex.krakovetskiy",
				GitHubUrl = "",
				GoogleUrl = "",
				LinkedInUrl = "https://www.linkedin.com/in/krakovetskiy/",
				MsdnUrl = "",
				MvpUrl = "",
				TwitterUrl = "https://twitter.com/msugvnua",
				YouTubeUrl = "",
				WebUrl = "",
				CompanyName = "DevRain Solutions",
				JobTitle = "CEO"
			};
		}

		public Speaker AYurchenko()
		{
			return new Speaker
			{
				Id = "AYurchenko",
				FirstName = Localization.App.Service.Speaker.AYurchenko.FirstName,
				LastName = Localization.App.Service.Speaker.AYurchenko.LastName,
				Bio = Localization.App.Service.Speaker.AYurchenko.Bio.Replace(Environment.NewLine, "<br/>"),
				Country = _countryService.Ukraine,
				PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/AYurchenko.jpg",
				FacebookUrl = "https://www.facebook.com/profile.php?id=100006139864997",
				GitHubUrl = "",
				GoogleUrl = "",
				LinkedInUrl = "",
				MsdnUrl = "",
				MvpUrl = "",
				TwitterUrl = "",
				YouTubeUrl = "",
				WebUrl = "",
				CompanyName = "EasyPay",
				JobTitle = "Developer"
			};
		}

		public Speaker VRadchuk()
		{
			return new Speaker
			{
				Id = "VRadchuk",
				FirstName = Localization.App.Service.Speaker.VRadchuk.FirstName,
				LastName = Localization.App.Service.Speaker.VRadchuk.LastName,
				Bio = Localization.App.Service.Speaker.VRadchuk.Bio.Replace(Environment.NewLine, "<br/>"),
				Country = _countryService.Ukraine,
				PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/VRadchuk.jpg",
				FacebookUrl = "",
				GitHubUrl = "",
				GoogleUrl = "",
				LinkedInUrl = "https://www.linkedin.com/in/valentineradchuk/",
				MsdnUrl = "",
				MvpUrl = "",
				TwitterUrl = "",
				YouTubeUrl = "",
				WebUrl = "",
				CompanyName = "Cogniance",
				JobTitle = "Lead .NET Developer"
			};
		}

		public Speaker ATkachenko()
		{
			return new Speaker
			{
				Id = "ATkachenko",
				FirstName = Localization.App.Service.Speaker.ATkachenko.FirstName,
				LastName = Localization.App.Service.Speaker.ATkachenko.LastName,
				Bio = Localization.App.Service.Speaker.ATkachenko.Bio.Replace(Environment.NewLine, "<br/>"),
				Country = _countryService.Ukraine,
				PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/_Person.png",
				FacebookUrl = "",
				GitHubUrl = "",
				GoogleUrl = "",
				LinkedInUrl = "",
				MsdnUrl = "",
				MvpUrl = "",
				TwitterUrl = "",
				YouTubeUrl = "",
				WebUrl = "",
				CompanyName = "",
				JobTitle = ""
			};
		}
	}
}
