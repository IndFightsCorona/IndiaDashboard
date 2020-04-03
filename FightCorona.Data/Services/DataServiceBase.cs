using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using FightCorona.Data.Helper;

namespace FightCorona.Data.Services
{
    public class DataServiceBase
    {
        public List<T> Execute<T>(string scriptText, object parameters = null,
            SqlTransaction tran = null)
        {
            SqlConnection conn = new SqlConnection(SqlDbContextHelper.GetConnectionString());
            try
            {
                var result = conn.Query<T>(scriptText, parameters, tran);
                return result?.ToList();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        public Boolean Execute(string scriptText, object parameters = null,
           SqlTransaction tran = null)
        {
            SqlConnection conn = new SqlConnection(SqlDbContextHelper.GetConnectionString());
            try
            {
                var result = conn.Execute(scriptText, parameters, tran);
                return result==1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
