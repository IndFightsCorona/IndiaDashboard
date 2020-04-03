using System.Web.Mvc;
using FightCorona.Business.Services;

namespace FightCorona.UI.Controllers
{
    public class WorldController : Controller
    {
        private readonly WorldDashboardViewService _dashboardViewService;

        public WorldController()
        {
            _dashboardViewService = new WorldDashboardViewService();
        }

        [OutputCache(Duration = 86400, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View(_dashboardViewService.GetDashboardData());
        }
    }
}