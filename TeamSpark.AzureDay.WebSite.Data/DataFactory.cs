using System;
using System.Threading.Tasks;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Data.Service.Table;

namespace TeamSpark.AzureDay.WebSite.Data
{
	public static class DataFactory
	{
		public static readonly Lazy<AttendeeService> AttendeeService = new Lazy<AttendeeService>(() => new AttendeeService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey));
		public static readonly Lazy<QuickAuthTokenService> QuickAuthTokenService = new Lazy<QuickAuthTokenService>(() => new QuickAuthTokenService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey));
		public static readonly Lazy<PartnerService> PartnerService = new Lazy<PartnerService>(() => new PartnerService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey));
		public static readonly Lazy<CouponService> CouponService = new Lazy<CouponService>(() => new CouponService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey));
		public static readonly Lazy<TicketService> TicketService = new Lazy<TicketService>(() => new TicketService(Configuration.AzureStorageAccountName, Configuration.AzureStorageAccountKey));

		public static async Task InitializeAsync()
		{
			await Task.WhenAll(
				AttendeeService.Value.InitializeAsync(),
				QuickAuthTokenService.Value.InitializeAsync(),
				PartnerService.Value.InitializeAsync(),
				CouponService.Value.InitializeAsync(),
				TicketService.Value.InitializeAsync()
			);
		}
	}
}
