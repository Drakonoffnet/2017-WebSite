using System;
using System.Web;
using System.Web.Mvc;

namespace TeamSpark.AzureDay.WebSite.Host.Controllers
{
	public class LanguageController : Controller
	{
		public const string LANGUAGE_COOKIE = "AzureDay.Ukraine.2017.Language";

		public ActionResult Index(string culture)
		{
			var request = HttpContext.Request;

			var languageCookie = request.Cookies[LANGUAGE_COOKIE];
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

			if (request.UrlReferrer != null)
			{
				return Redirect(request.UrlReferrer.AbsoluteUri);
			}
			else
			{
				return RedirectToAction("Index", "Home");
			}
		}
	}
}