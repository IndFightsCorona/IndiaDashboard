using System;
using System.Collections.Generic;
using System.Linq;
using FightCorona.Data.Services;
using FightCorona.Localization;
using FightCorona.Models;

namespace FightCorona.Business.Services
{
    public class StatesDashboardViewService
    {
        private readonly StatesDataService _stateDataService;
        private static TimeZoneInfo India_Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        public StatesDashboardViewService()
        {
            _stateDataService = new StatesDataService();
        }

        #region Public Methods

        public DashboardData GetDashboardData(string id)
        {
            var lastTwoDates = _stateDataService.GetLastTwoDates();
            var districtWiseStatus = _stateDataService.GetDistrictData(ConvertToIndiaDateTimeString(lastTwoDates.First()));

            return new DashboardData
            {
                PanelData = GetDashboardPanelData(districtWiseStatus, lastTwoDates.Last()),
                LastUpdated = TimeZoneInfo.ConvertTimeFromUtc(lastTwoDates.First(), India_Standard_Time),
                TableData = GetDistrictWiseData(districtWiseStatus)
            };
        }

        private DashboardPanelData GetDashboardPanelData(List<CurrentStatusData> districtWiseStatus, DateTime previousUpdatedTime)
        {
            var totalCases = districtWiseStatus.Sum(x => x.Total);
            var deaths = districtWiseStatus.Sum(x => x.Deaths);
            var recovered = districtWiseStatus.Sum(x => x.Cured);
            var activeCases = totalCases - deaths - recovered;

            return new DashboardPanelData
            {
                ActiveCases = activeCases,
                ActiveCasesVsTotalCases = Math.Round((activeCases/ (double)totalCases) * 100, 2),
                Deaths = deaths,
                DeathsVsTotalCases = Math.Round((deaths / (double)totalCases) * 100, 2),
                NewCases = totalCases - _stateDataService.GetConfirmedCasesCount(ConvertToIndiaDateTimeString(previousUpdatedTime)),
                Recovered = recovered,
                RecoveredVsTotalCases = Math.Round((recovered / (double)totalCases) * 100, 2),
                TotalCases = totalCases
            };
        }

        private DashboardTableData GetDistrictWiseData(List<CurrentStatusData> countryWiseStatus)
        {
            return new DashboardTableData
            {
                LocationDescription = LocalizationService.GetText(ResourceCategory.Dashboard, "District"),
                ResourceCategory = ResourceCategory.Districts,
                TableHeader = LocalizationService.GetText(ResourceCategory.Dashboard, "Districtwise_Status"),
                Items = countryWiseStatus
            };
        }

        private static string ConvertToIndiaDateTimeString(DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

   
        #endregion Public Methods
    }
}
