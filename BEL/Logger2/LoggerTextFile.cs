using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Belatrix.Helpers;

namespace Belatrix
{
    public class LoggerTextFile : ILogger
    {
        public void Log(string messageType, string message)
        {
            message = message + " - "  + messageType + Environment.NewLine;
            string directory = ConfigHelper.GetValue("LogFileDirectory");
            string file = directory + DateTime.Now.ToShortDateString().Replace(@"/", "") + "LogFile" + ".txt";
            string l = string.Empty;

            if (!File.Exists(file))
            {
                File.Create(file).Dispose();
            }

            l = File.ReadAllText(file);
            l = l + message;

            File.WriteAllText(file, l);
        }
    }
}