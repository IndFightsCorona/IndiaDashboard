using System;

namespace FightCorona.Models
{
    public class WorldDashboardData
    {
        public DashboardPanelData DashboardPanelData { get; set; }
        public DateTime LastUpdated { get; set; }
        public DashboardTableData CountryWiseData { get; set; }
    }
}
