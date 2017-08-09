using System;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.ApplicationInsights.Extensibility;
using TeamSpark.AzureDay.WebSite.Config;
using TeamSpark.AzureDay.WebSite.Host.Controllers;
//using TeamSpark.AzureDay.WebSite.Data;

namespace TeamSpark.AzureDay.WebSite.Host
{
	public class MvcApplication : HttpApplication
	{
		protected void Application_Start()
		{
			#region application insight

			TelemetryConfiguration.Active.InstrumentationKey = Configuration.ApplicationInsightInstrumentationKey;

			#endregion

			#region asp net mvc

			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			#endregion

			#region initialize

			//DataFactory.InitializeAsync().Wait();

			#endregion
		}

		private void Application_BeginRequest(Object source, EventArgs e)
		{
			var application = (HttpApplication)source;
			var context = application.Context;

			#if !DEBUG
			if (!context.Request.Url.Host.Equals(Configuration.Host, StringComparison.InvariantCultureIgnoreCase))
			{
				context.Response.Redirect($"{Configuration.Host}{context.Request.Url.AbsolutePath}");
			}
			#endif

			string culture;

			var languageCookie = context.Request.Cookies[LanguageController.LANGUAGE_COOKIE];
			if (languageCookie != null)
			{
				culture = languageCookie.Value;
			}
			else
			{
				if (context.Request.UserLanguages != null && context.Request.UserLanguages.Length > 0)
				{
					culture = context.Request.UserLanguages[0];
				}
				else
				{
					culture = "en";
				}
			}

			Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture);
			Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
		}
	}
}
