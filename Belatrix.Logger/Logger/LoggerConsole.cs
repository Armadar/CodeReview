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
    public class LoggerConsole : ILogger
    {
        public delegate void ColorHandler(ConsoleColor color, string messageType);
        public event ColorHandler onChange;
        public ConsoleColor ColorResult { get; set; }

        public void Log(string messageType, string message)
        {
            ConsoleColor r = ConsoleColor.White;
            switch (messageType)
            {
                case "Message":
                    r = ConsoleColor.White;
                    break;
                case "Warning":
                    r = ConsoleColor.Yellow;
                    break;
                case "Error":
                    r = ConsoleColor.Red;
                    break;
            }
            ColorResult = r;
            if (onChange != null)
            {
                onChange(r, messageType);
            }
        }
    }
}