using System;
using System.Collections.Generic;
using FightCorona.Models.Charts;

namespace FightCorona.Models
{
    public class IndiaDashboardData
    {
        public ChartConfig TotalCasesChart { get; set; }
        public ChartConfig NewCasesChart { get; set; }
        public DashboardPanelData DashboardPanelData { get; set; }
        public DateTime LastUpdated { get; set; }
        public DashboardTableData StateWiseData { get; set; }
    }
}
