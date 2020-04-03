namespace FightCorona.Models
{
    public class CurrentStatusData
    {
        public string Code { get; set; }

        public int Total { get; set; }
        public int PreviousTotal { get; set; }

        public int Active { get; set; }
        public int PreviousActive { get; set; }

        public int Cured { get; set; }
        public int PreviousCured { get; set; }

        public int Deaths { get; set; }
        public int PeviousDeaths { get; set; }
    }
}
