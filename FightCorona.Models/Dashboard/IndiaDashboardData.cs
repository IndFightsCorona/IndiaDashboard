using FightCorona.Models.Charts;

namespace FightCorona.Models
{
    public class IndiaDashboardData : DashboardData
    {
        public ChartConfig TotalCasesChart { get; set; }
        public ChartConfig NewCasesChart { get; set; }
    }
}
