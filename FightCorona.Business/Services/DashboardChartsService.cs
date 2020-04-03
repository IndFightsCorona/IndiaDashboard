using System.Collections.Generic;
using System.Linq;
using FightCorona.Data.Services;
using FightCorona.Localization;
using FightCorona.Models;
using FightCorona.Models.Charts;

namespace FightCorona.Business.Services
{
    public class DashboardChartsService
    {
        private readonly IndiaDataService _indiaDataService;

        public DashboardChartsService()
        {
            _indiaDataService = new IndiaDataService();
        }

        #region Public Methods

        public ChartConfig GetTotalCasesChart()
        {
            ChartConfig totalCasesChart = GetTotalCasesChartsConfig();
            var category = new List<CategoryItem>();
            var activeCasesSeriesData = new List<Datum>();
            var deathCasesSeriesData = new List<Datum>();

            var totalCasesOverDays = _indiaDataService.GetTotalCasesOverDaysData();
            var deathsOverDays = _indiaDataService.GetDeathsOverDaysData();
            var count = totalCasesOverDays?.Count;

            for(int i = 0; i< count; i++)
            {
                if (i % 2 == 0 || i >= count - 4)
                {
                    category.Add(new CategoryItem { Label = totalCasesOverDays[i].Label });
                    activeCasesSeriesData.Add(new Datum { Value = totalCasesOverDays[i].Value });
                    deathCasesSeriesData.Add(new Datum { Value = deathsOverDays[i].Value });
                }
            }

            totalCasesChart.DataSource.Categories.Add(
                 new CategoriesItem
                 {
                     Category = category
                 }
            );

            var activeCasesSeries = new Series
            {
                Seriesname = LocalizationService.GetText(ResourceCategory.Dashboard, "Confirmed"),
                Data = activeCasesSeriesData
            };

            var deathsSeries = new Series
            {
                Seriesname = LocalizationService.GetText(ResourceCategory.Dashboard, "Deaths"),
                Data = deathCasesSeriesData,
                Color = "#fc0202"
            };


            totalCasesChart.DataSource.Dataset.Add(activeCasesSeries);
            totalCasesChart.DataSource.Dataset.Add(deathsSeries);

            return totalCasesChart;
        }

        public ChartConfig GetNewCasesChart()
        {
            ChartConfig newCasesChart = GetNewCasesChartsConfig();
            newCasesChart.DataSource.Data = _indiaDataService.GetNewCasesOverDays();
            return newCasesChart;
        }

        #endregion Public Methods

        #region Private Methods

        private static ChartConfig GetTotalCasesChartsConfig()
        {
            return new ChartConfig
            {
                Type = "msline",
                RenderAt = "cases-over-days",
                Width = "100%",
                Height = "400",
                DataFormat = "json",
                DataSource = new DataSource
                {
                    Chart = new Chart
                    {
                        Caption = LocalizationService.GetText(ResourceCategory.Dashboard, "Confirmed"),
                        NumberSuffix = "",
                        Theme = "fusion",
                    },
                    Categories = new List<CategoriesItem>(),
                    Dataset = new List<Series>()
                }
            };
        }

        private static ChartConfig GetNewCasesChartsConfig()
        {
            return new ChartConfig
            {
                Type = "line",
                RenderAt = "new-cases-over-days",
                Width = "100%",
                Height = "400",
                DataFormat = "json",
                DataSource = new DataSource
                {
                    Chart = new Chart
                    {
                        Caption = LocalizationService.GetText(ResourceCategory.Dashboard, "NewCases"),
                        ShowValues = "1",
                        Theme = "fusion",
                    },
                    Categories = new List<CategoriesItem>(),
                    Dataset = new List<Series>()
                }
            };
        }
     
        #endregion Private Methods
    }
}
