using System;
using System.Collections.Generic;
using FightCorona.Models;

namespace FightCorona.Data.Services
{
    public class StatesDataService : DataServiceBase
    {
        public List<CurrentStatusData> GetDistrictData(string date)
        {
            var query = "select Location as Code, Confirmed as Total,Deaths, Recovered as Cured,Active from DistrictStatus where Date = '{0}'";
            return Execute<CurrentStatusData>(string.Format(query, date));
        }

        public List<DateTime> GetLastTwoDates()
        {
            var query = "select Distinct Top 2 Date from DistrictStatus order by Date desc";
            return Execute<DateTime>(query);
        }

        public int GetConfirmedCasesCount(string date)
        {
            var query = "select SUM(Confirmed) from DistrictStatus where Date = '{0}'";
            return Execute<int>(string.Format(query, date))[0];
        }

    }
}
