using System;
using System.Collections.Generic;
using System.Linq;
using TeamSpark.AzureDay.WebSite.App.Entity;
using TeamSpark.AzureDay.WebSite.Data.Enum;

namespace TeamSpark.AzureDay.WebSite.App.Service
{
	public sealed class PartnerService
	{
		private readonly List<Partner> _partners;

		public PartnerService()
		{
			_partners = new List<Partner>
			{
				new Partner
				{
					Id = "DataArt",
					Title = Localization.App.Service.Partners.DataArt.Title,
					Description = Localization.App.Service.Partners.DataArt.Description.Replace(Environment.NewLine, "<br/>"),
					LogoUrl = "https://azureday2017ua.blob.core.windows.net/images/logos/DA-logo-color-rgb.jpg",
					WebUrl = "http://dataart.ua",
					PartnerType = PartnerType.Info | PartnerType.Workshop
				},
				new Partner
				{
					Id = "Ciklum",
					Title = Localization.App.Service.Partners.Ciklum.Title,
					Description = Localization.App.Service.Partners.Ciklum.Description.Replace(Environment.NewLine, "<br/>"),
					LogoUrl = "https://azureday2017ua.blob.core.windows.net/images/logos/ciklum02.JPG",
					WebUrl = "https://www.ciklum.com",
					PartnerType = PartnerType.Info | PartnerType.Workshop | PartnerType.Bronze
				},
				new Partner
				{
					Id = "ITStep",
					Title = Localization.App.Service.Partners.ITStep.Title,
					Description = Localization.App.Service.Partners.ITStep.Description.Replace(Environment.NewLine, "<br/>"),
					LogoUrl = "https://azureday2017ua.blob.core.windows.net/images/logos/itstep02.JPG",
					WebUrl = "http://itstep.org/ua/",
					PartnerType = PartnerType.Info | PartnerType.Workshop
				},
				new Partner
				{
					Id = "Daxx",
					Title = Localization.App.Service.Partners.Daxx.Title,
					Description = Localization.App.Service.Partners.Daxx.Description.Replace(Environment.NewLine, "<br/>"),
					LogoUrl = "https://azureday2017ua.blob.core.windows.net/images/logos/daxx.jpg",
					WebUrl = "http://www.daxx.com",
					PartnerType = PartnerType.Info
				},
				new Partner
				{
					Id = "Microsoft",
					Title = Localization.App.Service.Partners.Microsoft.Title,
					Description = Localization.App.Service.Partners.Microsoft.Description.Replace(Environment.NewLine, "<br/>"),
					LogoUrl = "https://azureday2017ua.blob.core.windows.net/images/logos/microsoft.jpg",
					WebUrl = "https://www.microsoft.com/uk-ua/",
					PartnerType = PartnerType.Info | PartnerType.Gold
				},
				new Partner
				{
					Id = "EasyPay",
					Title = Localization.App.Service.Partners.EasyPay.Title,
					Description = Localization.App.Service.Partners.EasyPay.Description.Replace(Environment.NewLine, "<br/>"),
					LogoUrl = "https://azureday2017ua.blob.core.windows.net/images/logos/easypay.jpg",
					WebUrl = "https://easypay.ua/",
					PartnerType = PartnerType.Info | PartnerType.Speaker
				},
				new Partner
				{
					Id = "ITEA",
					Title = Localization.App.Service.Partners.ITEA.Title,
					Description = Localization.App.Service.Partners.ITEA.Description.Replace(Environment.NewLine, "<br/>"),
					LogoUrl = "https://azureday2017ua.blob.core.windows.net/images/logos/ITEA.jpg",
					WebUrl = "http://itea.ua/",
					PartnerType = PartnerType.Info
				}
			};
		}

		public IEnumerable<Partner> GetPartners()
		{
			return _partners
				.OrderBy(x => x.Id);
		}

		public IEnumerable<Partner> GetPartnersByType(PartnerType partnerType)
		{
			return _partners
				.Where(x => x.PartnerType.HasFlag(partnerType))
				.OrderBy(x => x.Id);
		}

		public Partner DataArt { get { return _partners.Single(x => x.Id == "DataArt"); } }
		public Partner Ciklum { get { return _partners.Single(x => x.Id == "Ciklum"); } }
		public Partner ITStep { get { return _partners.Single(x => x.Id == "ITStep"); } }
	}
}
