using System.Collections.Generic;

namespace FightCorona.Models
{
    public class DashboardTableData
    {
        public string TableHeader { get; set; }
        public string LocationDescription { get; set; }
        public ResourceCategory ResourceCategory { get; set; }
        public List<CurrentStatusData> Items { get; set; }
    }
}
