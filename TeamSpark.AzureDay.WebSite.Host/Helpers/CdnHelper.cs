using TeamSpark.AzureDay.WebSite.Config;

namespace TeamSpark.AzureDay.WebSite.Host.Helpers
{
	public static class CdnHelper
	{
		public static string GetCdnWebUrl(string url)
		{
			return $"{Configuration.CdnEndpointWeb}{url}";
		}

		public static string GetCdnWebStorage(string url)
		{
			return $"{Configuration.CdnEndpointStorage}{url}";
		}
	}
}