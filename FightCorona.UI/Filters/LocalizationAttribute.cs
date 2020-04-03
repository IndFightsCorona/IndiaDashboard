using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Web.Mvc;

namespace FightCorona.UI.Filters
{
    public class LocalizationAttribute : ActionFilterAttribute
    {
        private static string _defaultLanguage = "en";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string language = (string)filterContext.RouteData.Values["lang"];
            SetLanguage(language);
        }

        private static void SetLanguage(string language)
        {
            if (string.IsNullOrWhiteSpace(language) || !Constants.AllowedLanguages.Contains(language) || language == _defaultLanguage)
                return;
           
            try
            {
                CultureInfo info = new CultureInfo(language);
                info.NumberFormat = CultureInfo.CreateSpecificCulture("en-GB").NumberFormat;
                Thread.CurrentThread.CurrentUICulture = info;
                Thread.CurrentThread.CurrentCulture = info;
            }
            catch (Exception)
            {
                //Swallow the exception
            }
        }
    }
}