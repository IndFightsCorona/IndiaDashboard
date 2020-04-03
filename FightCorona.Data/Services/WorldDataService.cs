using System;
using System.Collections.Generic;
using FightCorona.Models;

namespace FightCorona.Data.Services
{
    public class WorldDataService : DataServiceBase
    {
        public List<CurrentStatusData> GetWorldData(string updateTime)
        {
            var query = "select Location as Code, Confirmed as Total,Deaths, Recovered as Cured,Active from countrystatus where LastUpdated = '{0}'";
            return Execute<CurrentStatusData>(string.Format(query, updateTime));
        }

        public List<DateTime> GetLastTwoUpdatedTime()
        {
            var query = "select Distinct Top 2 LastUpdated from CountryStatus order by LastUpdated desc";
            return Execute<DateTime>(query);
        }

        public int GetConfirmedCasesCount(string updateTime)
        {
            var query = "select SUM(Confirmed) from countrystatus where LastUpdated = '{0}'";
            return Execute<int>(string.Format(query, updateTime))[0];
        }

    }
}
