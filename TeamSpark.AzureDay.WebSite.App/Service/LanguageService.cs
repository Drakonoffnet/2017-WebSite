using System.Collections.Generic;
using System.Linq;
using TeamSpark.AzureDay.WebSite.App.Entity;

namespace TeamSpark.AzureDay.WebSite.App.Service
{
	public sealed class LanguageService
	{
		public IEnumerable<Language> GetLanguages()
		{
			var countries = new List<Language>
			{
				new Language {Id = 1, Title = Localization.App.Service.Language.Ukrainian},
				new Language {Id = 2, Title = Localization.App.Service.Language.Russian},
				new Language {Id = 2, Title = Localization.App.Service.Language.English}
			}
			.OrderBy(x => x.Title);

			return countries;
		}
	}
}
