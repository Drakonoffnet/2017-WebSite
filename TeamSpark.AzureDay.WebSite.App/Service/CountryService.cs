using System.Collections.Generic;
using System.Linq;
using TeamSpark.AzureDay.WebSite.App.Entity;

namespace TeamSpark.AzureDay.WebSite.App.Service
{
	public sealed class CountryService
	{
		private readonly List<Country> _countries = new List<Country>
		{
			new Country {Id = 1, ImageUrl = "https://azureday2017ua.blob.core.windows.net/images/flags/ua.png", Title = Localization.App.Service.Country.Ukraine},
			new Country {Id = 2, ImageUrl = "https://azureday2017ua.blob.core.windows.net/images/flags/ru.png", Title = Localization.App.Service.Country.Russia},
			new Country {Id = 3, ImageUrl = "https://azureday2017ua.blob.core.windows.net/images/flags/by.png", Title = Localization.App.Service.Country.Belarus},
			new Country {Id = 4, ImageUrl = "https://azureday2017ua.blob.core.windows.net/images/flags/fr.png", Title = Localization.App.Service.Country.France},
			new Country {Id = 5, ImageUrl = "https://azureday2017ua.blob.core.windows.net/images/flags/se.png", Title = Localization.App.Service.Country.Sweden}
		};

		public IEnumerable<Country> GetCountries()
		{
			return _countries.OrderBy(x => x.Title);
		}

		public Country Ukraine { get { return _countries.Single(x => x.Id == 1); } }
		public Country Russia { get { return _countries.Single(x => x.Id == 2); } }
		public Country Belarus { get { return _countries.Single(x => x.Id == 3); } }
		public Country France { get { return _countries.Single(x => x.Id == 4); } }
		public Country Sweden { get { return _countries.Single(x => x.Id == 5); } }
	}
}
