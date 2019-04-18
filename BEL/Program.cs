using Belatrix;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    class Program
    {
        static void Main(string[] args)
        {
            //JobLogger jl = new JobLogger(true, true, true, true, true, true);
            //JobLogger.LogMessage("belatrix", true, true, false);

            List<JobLogger.LogDestiny> destiny = new List<JobLogger.LogDestiny>();
            destiny.Add(JobLogger.LogDestiny.TextFile);
            destiny.Add(JobLogger.LogDestiny.Console);
            //destiny.Add(JobLogger.LogDestiny.DB); forced comment because there is not a real server, if you uncomment this line the LoggerDB would take some seconds to complete


            JobLogger jl = new JobLogger(destiny, null);

            jl.LogMessage("issue " + DateTime.Now.Ticks.ToString(), JobLogger.LogMessageType.Error);
            jl.LogMessage("issue " + DateTime.Now.Ticks.ToString(), JobLogger.LogMessageType.Error);
            jl.LogMessage("issue " + DateTime.Now.Ticks.ToString(), JobLogger.LogMessageType.Message);
            jl.LogMessage("issue " + DateTime.Now.Ticks.ToString(), JobLogger.LogMessageType.Message);
            jl.LogMessage("issue " + DateTime.Now.Ticks.ToString(), JobLogger.LogMessageType.Warning);
            jl.LogMessage("issue " + DateTime.Now.Ticks.ToString(), JobLogger.LogMessageType.Warning);
            Console.ReadKey();

        }
    }
}