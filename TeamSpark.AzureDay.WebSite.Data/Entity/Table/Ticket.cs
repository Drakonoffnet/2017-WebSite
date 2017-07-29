using Microsoft.WindowsAzure.Storage.Table;
using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.Data.Entity.Table
{
	public sealed class Ticket : TableEntity
	{
		[IgnoreProperty]
		public string AttendeeEMail
		{
			get => RowKey;
			set => RowKey = value;
		}

		public bool IsPayed { get; set; }

		public string CouponCode { get; set; }

		[IgnoreProperty]
		public TicketType TicketType
		{
			get => (TicketType)TicketTypeId;
			set => TicketTypeId = (int)value;
		}

		public int TicketTypeId
		{
			get => int.Parse(PartitionKey);
			set => PartitionKey = ((TicketType)value).ToDisplayString();
		}

		public int? WorkshopId { get; set; }

		public double Price { get; set; }

		public string PaymentType { get; set; }

		public Ticket()
		{
		}
	}
}
