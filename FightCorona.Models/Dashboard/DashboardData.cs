using System;

namespace FightCorona.Models
{
    public class DashboardData
    {
        public DashboardPanelData PanelData { get; set; }
        public DateTime LastUpdated { get; set; }
        public DashboardTableData TableData { get; set; }
    }
}
