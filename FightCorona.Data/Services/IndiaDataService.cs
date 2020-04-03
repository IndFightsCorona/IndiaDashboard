using System;
using System.Collections.Generic;
using FightCorona.Models;
using FightCorona.Models.Charts;
using FightCorona.UI.Models;

namespace FightCorona.Data.Services
{
    public class IndiaDataService : DataServiceBase
    {
        public List<Datum> GetTotalCasesOverDaysData()
        {
            var query = "Select Left(CONVERT(VARCHAR(10), LastUpdatedTime, 105), 5) as Label, TotalCasesOverDays as Value From OverallStatistics";
            return Execute<Datum>(query);
        }

        public List<Datum> GetDeathsOverDaysData()
        {
            var query = "Select Left(CONVERT(VARCHAR(10), LastUpdatedTime, 105), 5) as Label, DeathsOverDays as Value From OverallStatistics";
            return Execute<Datum>(query);
        }

        public List<Datum> GetNewCasesOverDays()
        {
            var query = "Select Left(CONVERT(VARCHAR(10), LastUpdatedTime, 105), 5) as Label, NewCasesOverDays as Value From OverallStatistics";
            return Execute<Datum>(query);
        }

        public DashboardPanelData GetDashboardPanelData()
        {
            var query = "Select Top 1 Active_COVID_2019_cases as ActiveCases,Cured_discharged_cases as Recovered,DeathsOverDays as Deaths,TotalCasesOverDays as TotalCases,NewCasesOverDays as NewCases, cast((cast(Active_COVID_2019_cases as float) / cast(TotalCasesOverDays as float)) * 100 as decimal(10, 2)) as ActiveCasesVsTotalCases,cast((cast(DeathsOverDays as float) / cast(TotalCasesOverDays as float)) * 100 as decimal(10, 2)) as DeathsVsTotalCases,cast((cast(Cured_discharged_cases as float) / cast(TotalCasesOverDays as float)) * 100 as decimal(10, 2)) as RecoveredVsTotalCases From OverallStatistics ORDER BY LastUpdatedTime DESC";
            return Execute<DashboardPanelData>(query)[0];
        }

        public Boolean InsertContactUs(ContactUsModel model)
        {
            var query = "INSERT INTO [dbo].[ContactUs]([Name],[Email],[Suggestions],[CreatedDate]) VALUES (@Name,@Email,@Suggestions,@CreatedDate)";
            return Execute(query, new
            {
                model.Name,
                model.Email,
                model.Suggestions,
                model.CreatedDate
            });
        }

        public DateTime GetLastUpdatedDate()
        {
            var query = "Select Top 1 LastUpdated  From LastUpdates";
            return Execute<DateTime>(query)[0];
        }
        public List<CurrentStatusData> GetStateWiseData()
        {
            var query = "select Top 30 State_UT_Code as Code,Total_Confirmed_cases_Indian_National as Total,Death as Deaths,Cured_Discharged_Migrated as Cured, Version from [statistics] a order by a.Version desc";
            return Execute<CurrentStatusData>(query);
        }
        
    }
}
