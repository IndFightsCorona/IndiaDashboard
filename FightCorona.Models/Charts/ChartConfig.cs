using System.Collections.Generic;

namespace FightCorona.Models.Charts
{
    public class ChartConfig
    {
        public string Type { get; set; }
        public string RenderAt { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string DataFormat { get; set; }
        public DataSource DataSource { get; set; }
    }
}
