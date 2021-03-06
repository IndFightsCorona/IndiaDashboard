﻿using System.Web.Mvc;
using FightCorona.Business.Services;
using FightCorona.UI.Models;

namespace FightCorona.UI.Controllers
{
    public class IndiaController : Controller
    {
        private readonly IndiaDashboardViewService _dashboardViewService;
        private readonly ContactUsService _contactUSService;
        private readonly StatesDashboardViewService _statesDashboardViewService;

        public IndiaController()
        {
            _dashboardViewService = new IndiaDashboardViewService();
            _contactUSService = new ContactUsService();
            _statesDashboardViewService = new StatesDashboardViewService();
        }

        [OutputCache(Duration = 86400, VaryByParam = "none")]
        public ActionResult Index()
        {
            return View(_dashboardViewService.GetDashboardData());
        }

        public ActionResult States(string id)
        {
            return View(_statesDashboardViewService.GetDashboardData(id));
        }

        [HttpPost]
        public JsonResult Index(ContactUsModel Model)
        {
            if (_contactUSService.InsertContactUs(Model))
                return Json("Success", JsonRequestBehavior.AllowGet);

            return Json("Error", JsonRequestBehavior.AllowGet);
        }
    }
}