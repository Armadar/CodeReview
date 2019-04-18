using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix.Helpers
{
    public class ConfigHelper
    {
        public static string GetValue(string key)
        {
            string r = string.Empty;
            try
            {
                r = ConfigurationManager.AppSettings[key].ToString();
            }
            catch (Exception e)
            {
                throw new Exception("Configuration Exception: " + e);
            }            
            return r;
        }
        public static string GetConnString()
        {
            string r = string.Empty;
            try
            {
                r = ConfigurationManager.ConnectionStrings["Test"].ConnectionString;
            }
            catch (Exception e)
            {
                throw new Exception("Configuration Exception: " + e);
            }            
            return r;
        }
    }
}