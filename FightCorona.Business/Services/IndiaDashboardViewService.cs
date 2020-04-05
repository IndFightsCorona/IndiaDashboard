using FightCorona.Data.Services;
using FightCorona.Localization;
using FightCorona.Models;

namespace FightCorona.Business.Services
{
    public class IndiaDashboardViewService
    {
        private readonly DashboardChartsService _dashboardChartsService;
        private readonly IndiaDataService _indiaDataService;

        public IndiaDashboardViewService()
        {
            _dashboardChartsService = new DashboardChartsService();
            _indiaDataService = new IndiaDataService();
        }

        #region Public Methods

        public IndiaDashboardData GetDashboardData()
        {
            return new IndiaDashboardData
            {
                TotalCasesChart = _dashboardChartsService.GetTotalCasesChart(),
                NewCasesChart = _dashboardChartsService.GetNewCasesChart(),
                PanelData = _indiaDataService.GetDashboardPanelData(),
                LastUpdated = _indiaDataService.GetLastUpdatedDate(),
                TableData = GetStateWiseData()
            };
        }

        private DashboardTableData GetStateWiseData()
        {
            return new DashboardTableData
            {
                LocationDescription = LocalizationService.GetText(ResourceCategory.Dashboard, "NAMEOFSTATES"),
                ResourceCategory = ResourceCategory.States,
                TableHeader = LocalizationService.GetText(ResourceCategory.Dashboard, "Statewise_Status"),
                Items = _indiaDataService.GetStateWiseData()
            };
        }
        #endregion Public Methods
    }
}
