using System;
using System.Configuration;

namespace TeamSpark.AzureDay.WebSite.Config
{
	public static class Configuration
	{
		#region general

		public static string Year => "2017";
		public static string Host => "https://azureday.net";

		#endregion

		#region cdn

		public static string CdnEndpointWeb => GetConfigVariable("CdnEndpointWeb");

		public static string CdnEndpointStorage => GetConfigVariable("CdnEndpointStorage");

		#endregion

		#region azure storage

		public static string AzureStorageAccountName => GetConfigVariable("AzureStorageAccountName");
		public static string AzureStorageAccountKey => GetConfigVariable("AzureStorageAccountKey");

		#endregion

		#region application insight

		public static string ApplicationInsightInstrumentationKey => GetConfigVariable("ApplicationInsightInstrumentationKey");
		public static string ApplicationInsightEnvironmentTag => GetConfigVariable("ApplicationInsightEnvironmentTag");

		#endregion

		#region sendgrid

		public static string SendGridApiKey => GetConfigVariable("SendGridApiKey");
		public static string SendGridFromEmail => GetConfigVariable("SendGridFromEmail");
		public static string SendGridFromName => GetConfigVariable("SendGridFromName");

		#endregion

		#region kaznachey

		public static Guid KaznackeyMerchantId => Guid.Parse(GetConfigVariable("KaznackeyMerchantId"));
		public static string KaznackeyMerchantSecreet => GetConfigVariable("KaznackeyMerchantSecreet");

		#endregion

		#region tickets

		public static decimal TicketRegular => 750;
		public static decimal TicketWorkshop => 1750;

		#endregion

		private static string GetConfigVariable(string name)
		{
			var value = Environment.GetEnvironmentVariable(name);

			if (string.IsNullOrEmpty(value))
			{
				value = ConfigurationManager.AppSettings.Get(name);
			}

			if (string.IsNullOrEmpty(value))
			{
				return string.Empty;
			}

			return value;
		}
	}
}
