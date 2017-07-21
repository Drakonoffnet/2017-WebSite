using System.Collections.Generic;
using System.Linq;
using TeamSpark.AzureDay.WebSite.App.Entity;

namespace TeamSpark.AzureDay.WebSite.App.Service
{
	public sealed class CountryService
	{
		public IEnumerable<Country> GetCountries()
		{
			var countries = new List<Country>
			{
				new Country {Id = 1, Title = Localization.App.Service.Country.Ukraine},
				new Country {Id = 2, Title = Localization.App.Service.Country.Russia},
				new Country {Id = 3, Title = Localization.App.Service.Country.Belarus},
				new Country {Id = 4, Title = Localization.App.Service.Country.France},
				new Country {Id = 5, Title = Localization.App.Service.Country.Sweden}
			}
			.OrderBy(x => x.Title);

			return countries;
		}
	}
}
