using System.Web.Mvc;
using FightCorona.UI.Filters;

namespace FightCorona.UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new LocalizationAttribute(), 0);
        }
    }
}
