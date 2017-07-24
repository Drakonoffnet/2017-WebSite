namespace TeamSpark.AzureDay.WebSite.Host.Models.Profile
{
	public sealed class PayModel
	{
		public bool cbConferenceTicket { get; set; }
		public bool cbWorkshopTicket { get; set; }
		public int ddlWorkshop { get; set; }
		public string paymentType { get; set; }
		public string promoCode { get; set; }
	}
}