using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightCorona.Data.Helper
{
    public static class SqlDbContextHelper
    {
        public static string GetConnectionString()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Default"]?.ConnectionString;
            return connectionString;
        }
    }
}
