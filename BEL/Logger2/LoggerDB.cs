using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Belatrix.Helpers;

namespace Belatrix
{
    public  class LoggerDB : ILogger
    {
        public void Log(string messageType, string message)
        {
            string connStr = ConfigHelper.GetConnString();
            using (SqlConnection con = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertLog", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@pKind", SqlDbType.VarChar).Value = messageType;
                    cmd.Parameters.Add("@pMessage", SqlDbType.VarChar).Value = message;

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}