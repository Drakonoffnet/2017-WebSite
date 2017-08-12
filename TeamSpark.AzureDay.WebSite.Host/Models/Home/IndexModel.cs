using System.Collections.Generic;
using TeamSpark.AzureDay.WebSite.App.Entity;

namespace TeamSpark.AzureDay.WebSite.Host.Models.Home
{
	public sealed class IndexModel
	{
		public SpeakersModel Speakers { get; set; }
		public List<Partner> Partners { get; set; }
	}
}