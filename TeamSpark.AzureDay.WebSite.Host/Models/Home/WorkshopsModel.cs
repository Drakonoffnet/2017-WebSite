using System.Collections.Generic;
using TeamSpark.AzureDay.WebSite.App.Entity;

namespace TeamSpark.AzureDay.WebSite.Host.Models.Home
{
	public sealed class WorkshopsModel
	{
		public List<Workshop> Workshops { get; set; }
		public Dictionary<int, int> TicketsLeft { get; set; }
	}
}