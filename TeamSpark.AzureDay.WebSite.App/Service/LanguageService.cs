using System.Collections.Generic;
using System.Linq;
using TeamSpark.AzureDay.WebSite.App.Entity;

namespace TeamSpark.AzureDay.WebSite.App.Service
{
	public sealed class LanguageService
	{
		private readonly List<Language> _languages = new List<Language>
		{
			new Language {Id = 1, Title = Localization.App.Service.Language.Ukrainian},
			new Language {Id = 2, Title = Localization.App.Service.Language.Russian},
			new Language {Id = 2, Title = Localization.App.Service.Language.English}
		};

		public IEnumerable<Language> GetLanguages()
		{
			return _languages.OrderBy(x => x.Title);
		}

		public Language Ukrainian { get { return _languages.Single(x => x.Id == 1); } }
		public Language Russian { get { return _languages.Single(x => x.Id == 2); } }
		public Language English { get { return _languages.Single(x => x.Id == 3); } }
	}
}
