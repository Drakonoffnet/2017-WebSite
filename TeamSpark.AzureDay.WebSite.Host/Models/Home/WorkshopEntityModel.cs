using TeamSpark.AzureDay.WebSite.App.Entity;

namespace TeamSpark.AzureDay.WebSite.Host.Models.Home
{
	public sealed class WorkshopEntityModel
	{
		public Workshop Workshop { get; set; }
		public int TicketsLeft { get; set; }
		public bool ShowSpeakerInfo { get; set; }
	}
}