namespace FightCorona.Models
{
    public class DashboardPanelData
    {
        public int TotalCases { get; set; }
        public int NewCases { get; set; }
        public int ActiveCases { get; set; }
        public double ActiveCasesVsTotalCases { get; set; }
        public int Recovered { get; set; }
        public double RecoveredVsTotalCases { get; set; }
        public int Deaths { get; set; }
        public double DeathsVsTotalCases { get; set; }
    }
}
