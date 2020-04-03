using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace FightCorona.UI.Controllers
{
    public class CacheController : Controller
    {
        [HttpGet]
        public JsonResult Reset()
        {
            //removing cache for english
            HttpResponse.RemoveOutputCacheItem(Url.Action(""));
            HttpResponse.RemoveOutputCacheItem(Url.Action("", "india"));
            HttpResponse.RemoveOutputCacheItem(Url.Action("", "world"));

            //removing cache for all other locale
            foreach (var item in Constants.AllowedLanguages)
            {
                RouteValueDictionary routeValueDictionary = new RouteValueDictionary
                {
                    { "lang", item }
                };
                HttpResponse.RemoveOutputCacheItem(Url.Action("", routeValueDictionary));
                HttpResponse.RemoveOutputCacheItem(Url.Action("", "india", routeValueDictionary));
                HttpResponse.RemoveOutputCacheItem(Url.Action("", "world", routeValueDictionary));
            }
            return Json(new { CacheResetted = "true", ResettedFor = Constants.AllowedLanguages }, JsonRequestBehavior.AllowGet);
        }
    }
}