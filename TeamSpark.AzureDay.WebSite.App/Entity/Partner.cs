using System;
using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.App.Entity
{
	public class Partner
	{
		public string Id { get; set; }
		public string Title { get; set; }
		public string LogoUrl { get; set; }
		public string WebUrl { get; set; }
		public string Description { get; set; }
		public PartnerType PartnerType { get; set; }
	}
}
