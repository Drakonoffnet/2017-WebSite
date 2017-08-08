using Microsoft.WindowsAzure.Storage.Table;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.Data.Entity.Table
{
	public sealed class Coupon : TableEntity
	{
		[IgnoreProperty]
		public string Code
		{
			get => RowKey;
			set => RowKey = value;
		}

		[IgnoreProperty]
		public DiscountType DiscountType
		{
			get => (DiscountType)DiscountTypeId;
			set => DiscountTypeId = (int)value;
		}

		public int DiscountTypeId { get; set; }

		[IgnoreProperty]
		public decimal DiscountAmount
		{
			get => (decimal)DiscountAmountValue;
			set => DiscountAmountValue = (float)value;
		}

		public double DiscountAmountValue { get; set; }

		public bool IsEnabled { get; set; }

		public bool IsInfinite { get; set; }

		public int CouponsCount { get; set; }

		public Coupon()
		{
			PartitionKey = Configuration.Year;
		}
	}
}
