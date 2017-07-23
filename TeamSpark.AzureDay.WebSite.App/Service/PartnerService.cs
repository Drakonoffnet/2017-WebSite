using System.Collections.Generic;
using TeamSpark.AzureDay.WebSite.App.Entity;

namespace TeamSpark.AzureDay.WebSite.App.Service
{
	public sealed class PartnerService
	{
		private readonly List<Partner> _partners = new List<Partner>();

		public IEnumerable<Partner> GetPartners()
		{
			return _partners;
		}
	}
}
