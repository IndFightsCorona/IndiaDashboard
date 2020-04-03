using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightCorona.Models.Charts
{
    public class Chart
    {
        public string Caption { get; set; }
        public string SubCaption { get; set; }
        public string XAxisName { get; set; }
        public string YAxisName { get; set; }
        public string ShowValues { get; set; }
        public string NumberSuffix { get; set; }
        public string Theme { get; set; }
    }
}
