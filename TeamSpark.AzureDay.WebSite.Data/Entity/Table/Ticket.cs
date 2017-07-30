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
			get
			{
				TicketType val;
				return System.Enum.TryParse(PartitionKey, true, out val) ?
					val :
					TicketType.None;
			}
			set => PartitionKey = value.ToString();
		}

		public int? WorkshopId { get; set; }

		public double Price { get; set; }

		public string PaymentType { get; set; }

		public Ticket()
		{
		}
	}
}
