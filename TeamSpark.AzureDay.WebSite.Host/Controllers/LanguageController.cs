using System;
using System.Web;
using System.Web.Mvc;

namespace TeamSpark.AzureDay.WebSite.Host.Controllers
{
	public class LanguageController : Controller
	{
		public const string LANGUAGE_COOKIE = "AzureDay.Ukraine.2017.Language";

		// GET: Language
		public ActionResult Index(string culture)
		{
			var languageCookie = HttpContext.Request.Cookies[LANGUAGE_COOKIE];
			if (languageCookie == null)
			{
				languageCookie = new HttpCookie(LANGUAGE_COOKIE, culture);
				languageCookie.Expires = DateTime.MaxValue;
			}
			else
			{
				languageCookie.Value = culture;
			}
			HttpContext.Response.Cookies.Add(languageCookie);

			return RedirectToAction("Index", "Home");
		}
	}
}