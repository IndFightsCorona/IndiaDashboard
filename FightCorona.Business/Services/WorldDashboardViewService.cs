using System;
using System.Collections.Generic;
using System.Linq;
using FightCorona.Data.Services;
using FightCorona.Localization;
using FightCorona.Models;

namespace FightCorona.Business.Services
{
    public class WorldDashboardViewService
    {
        private readonly WorldDataService _worldDataService;
        private static TimeZoneInfo India_Standard_Time = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");

        public WorldDashboardViewService()
        {
            _worldDataService = new WorldDataService();
        }

        #region Public Methods

        public DashboardData GetDashboardData()
        {
            var lastTwoUpdatedTime = _worldDataService.GetLastTwoUpdatedTime();
            var countryWiseStatus = _worldDataService.GetWorldData(ConvertToIndiaDateTimeString(lastTwoUpdatedTime.First()));

            return new DashboardData
            {
                PanelData = GetDashboardPanelData(countryWiseStatus, lastTwoUpdatedTime.Last()),
                LastUpdated = TimeZoneInfo.ConvertTimeFromUtc(lastTwoUpdatedTime.First(), India_Standard_Time),
                TableData = GetCountryWiseData(countryWiseStatus)
            };
        }

        private DashboardPanelData GetDashboardPanelData(List<CurrentStatusData> countryWiseStatus, DateTime previousUpdatedTime)
        {
            var totalCases = countryWiseStatus.Sum(x => x.Total);
            var deaths = countryWiseStatus.Sum(x => x.Deaths);
            var recovered = countryWiseStatus.Sum(x => x.Cured);
            var activeCases = totalCases - deaths - recovered;

            return new DashboardPanelData
            {
                ActiveCases = activeCases,
                ActiveCasesVsTotalCases = Math.Round((activeCases/ (double)totalCases) * 100, 2),
                Deaths = deaths,
                DeathsVsTotalCases = Math.Round((deaths / (double)totalCases) * 100, 2),
                NewCases = totalCases - _worldDataService.GetConfirmedCasesCount(ConvertToIndiaDateTimeString(previousUpdatedTime)),
                Recovered = recovered,
                RecoveredVsTotalCases = Math.Round((recovered / (double)totalCases) * 100, 2),
                TotalCases = totalCases
            };
        }

        private DashboardTableData GetCountryWiseData(List<CurrentStatusData> countryWiseStatus)
        {
            return new DashboardTableData
            {
                LocationDescription = LocalizationService.GetText(ResourceCategory.Dashboard, "Country"),
                ResourceCategory = ResourceCategory.Countries,
                TableHeader = LocalizationService.GetText(ResourceCategory.Dashboard, "Countrywise_Status"),
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
