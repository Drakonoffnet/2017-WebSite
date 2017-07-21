using TeamSpark.AzureDay.WebSite.Config;

namespace TeamSpark.AzureDay.WebSite.App.Entity
{
	public class Country
	{
		public int Id { get; set; }
		public string Title { get; set; }

		public string GetImageUrl()
		{
			return $"https://{Configuration.AzureStorageAccountName}.blob.core.windows.net/azureday/{Configuration.Year}/countries/{Id}.GIF";
		}
	}
}
