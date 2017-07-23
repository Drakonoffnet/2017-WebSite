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
			_speakers.Add(MMartensson());
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
		}

		public IEnumerable<Speaker> GetSpeakers()
		{
			return _speakers;
		}

		public Speaker ABoyko()
		{
			return new Speaker
			{
				Id = 1,
				FirstName = Localization.App.Service.Speaker.ABoyko.FirstName,
				LastName = Localization.App.Service.Speaker.ABoyko.LastName,
				Bio = Localization.App.Service.Speaker.ABoyko.Bio,
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
				WebUrl = ""
			};
		}

		public Speaker ALaysha()
		{
			return new Speaker
			{
				Id = 2,
				FirstName = Localization.App.Service.Speaker.ALaysha.FirstName,
				LastName = Localization.App.Service.Speaker.ALaysha.LastName,
				Bio = Localization.App.Service.Speaker.ALaysha.Bio,
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
				WebUrl = ""
			};
		}

		public Speaker OChorny()
		{
			return new Speaker
			{
				Id = 3,
				FirstName = Localization.App.Service.Speaker.OChorny.FirstName,
				LastName = Localization.App.Service.Speaker.OChorny.LastName,
				Bio = Localization.App.Service.Speaker.OChorny.Bio,
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
				WebUrl = ""
			};
		}

		public Speaker DDurasau()
		{
			return new Speaker
			{
				Id = 4,
				FirstName = Localization.App.Service.Speaker.DDurasau.FirstName,
				LastName = Localization.App.Service.Speaker.DDurasau.LastName,
				Bio = Localization.App.Service.Speaker.DDurasau.Bio,
				Country = _countryService.Belarus,
				PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/_Person.png",
				FacebookUrl = "",
				GitHubUrl = "",
				GoogleUrl = "",
				LinkedInUrl = "",
				MsdnUrl = "",
				MvpUrl = "",
				TwitterUrl = "",
				YouTubeUrl = "",
				WebUrl = ""
			};
		}

		public Speaker IFesenko()
		{
			return new Speaker
			{
				Id = 5,
				FirstName = Localization.App.Service.Speaker.IFesenko.FirstName,
				LastName = Localization.App.Service.Speaker.IFesenko.LastName,
				Bio = Localization.App.Service.Speaker.IFesenko.Bio,
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
				WebUrl = "https://www.ifesenko.com/"
			};
		}

		public Speaker DIvanov()
		{
			return new Speaker
			{
				Id = 6,
				FirstName = Localization.App.Service.Speaker.DIvanov.FirstName,
				LastName = Localization.App.Service.Speaker.DIvanov.LastName,
				Bio = Localization.App.Service.Speaker.DIvanov.Bio,
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
				WebUrl = ""
			};
}

		public Speaker SKorzh()
		{
			return new Speaker
			{
				Id = 7,
				FirstName = Localization.App.Service.Speaker.SKorzh.FirstName,
				LastName = Localization.App.Service.Speaker.SKorzh.LastName,
				Bio = Localization.App.Service.Speaker.SKorzh.Bio,
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
				WebUrl = ""
			};
		}

		public Speaker SKryshtop()
		{
			return new Speaker
			{
				Id = 8,
				FirstName = Localization.App.Service.Speaker.SKryshtop.FirstName,
				LastName = Localization.App.Service.Speaker.SKryshtop.LastName,
				Bio = Localization.App.Service.Speaker.SKryshtop.Bio,
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
				WebUrl = ""
			};
		}

		public Speaker ILeontiev()
		{
			return new Speaker
			{
				Id = 9,
				FirstName = Localization.App.Service.Speaker.ILeontiev.FirstName,
				LastName = Localization.App.Service.Speaker.ILeontiev.LastName,
				Bio = Localization.App.Service.Speaker.ILeontiev.Bio,
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
				WebUrl = ""
			};
		}

		public Speaker MMartensson()
		{
			return new Speaker
			{
				Id = 10,
				FirstName = Localization.App.Service.Speaker.MMartensson.FirstName,
				LastName = Localization.App.Service.Speaker.MMartensson.LastName,
				Bio = Localization.App.Service.Speaker.MMartensson.Bio,
				Country = _countryService.Sweden,
				PhotoUrl = "https://azureday2017ua.blob.core.windows.net/images/avatars/MMartensson.jpg",
				FacebookUrl = "https://www.facebook.com/noopman",
				GitHubUrl = "",
				GoogleUrl = "",
				LinkedInUrl = "https://www.linkedin.com/in/noopman",
				MsdnUrl = "",
				MvpUrl = "",
				TwitterUrl = "https://twitter.com/noopman",
				YouTubeUrl = "",
				WebUrl = ""
			};
		}

		public Speaker EPolonychko()
		{
			return new Speaker
			{
				Id = 11,
				FirstName = Localization.App.Service.Speaker.EPolonychko.FirstName,
				LastName = Localization.App.Service.Speaker.EPolonychko.LastName,
				Bio = Localization.App.Service.Speaker.EPolonychko.Bio,
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
				WebUrl = ""
			};
		}

		public Speaker DReznik()
		{
			return new Speaker
			{
				Id = 12,
				FirstName = Localization.App.Service.Speaker.DReznik.FirstName,
				LastName = Localization.App.Service.Speaker.DReznik.LastName,
				Bio = Localization.App.Service.Speaker.DReznik.Bio,
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
				WebUrl = ""
			};
		}

		public Speaker IReznykov()
		{
			return new Speaker
			{
				Id = 13,
				FirstName = Localization.App.Service.Speaker.IReznykov.FirstName,
				LastName = Localization.App.Service.Speaker.IReznykov.LastName,
				Bio = Localization.App.Service.Speaker.IReznykov.Bio,
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
				WebUrl = "https://ireznykov.com"
			};
		}

		public Speaker ASurkov()
		{
			return new Speaker
			{
				Id = 14,
				FirstName = Localization.App.Service.Speaker.ASurkov.FirstName,
				LastName = Localization.App.Service.Speaker.ASurkov.LastName,
				Bio = Localization.App.Service.Speaker.ASurkov.Bio,
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
				WebUrl = ""
			};
		}

		public Speaker VThavonekham()
		{
			return new Speaker
			{
				Id = 15,
				FirstName = Localization.App.Service.Speaker.VThavonekham.FirstName,
				LastName = Localization.App.Service.Speaker.VThavonekham.LastName,
				Bio = Localization.App.Service.Speaker.VThavonekham.Bio,
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
				WebUrl = ""
			};
		}

		public Speaker MSmereczynski()
		{
			return new Speaker
			{
				Id = 15,
				FirstName = Localization.App.Service.Speaker.MSmereczynski.FirstName,
				LastName = Localization.App.Service.Speaker.MSmereczynski.LastName,
				Bio = Localization.App.Service.Speaker.MSmereczynski.Bio,
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
				WebUrl = ""
			};
		}
	}
}
