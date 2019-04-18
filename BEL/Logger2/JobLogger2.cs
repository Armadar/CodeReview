using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix
{
    public class JobLogger2
    {
        public enum LogDestiny
        {
            TextFile = 0,
            Console = 1,
            DB = 2
        }
        public enum LogMessageType
        {
            Message = 0,
            Warning = 1,
            Error = 2
        }
        public enum LogMode
        {
            OnlyErrors = 0,
            ErrorsAndWarnings = 2
        }

        IList<LogDestiny> destiny;
        LogMessageType messageType;
        LogMode? mode;
        string message;

        public JobLogger2(IList<LogDestiny> destiny, LogMode? mode)
        {
            this.destiny = destiny;            
            this.mode = mode;
        }

        public void LogMessage(string message, LogMessageType messageType)
        {            
            message.Trim();
            this.message = message;
            this.messageType = messageType;

            if (message == null || message.Length == 0)
            {
                return;
            }
            if (destiny.Count > 3)
            {
                return;
            }
            destiny.ToList().ForEach(d =>
            {
                if (validateLogMode(mode, messageType))
                {
                    Work(d);
                }
            });
        }
        bool validateLogMode(LogMode? mode, LogMessageType type)
        {
            bool r = true;
            switch (mode)
            {
                case null:
                    break;
                case LogMode.OnlyErrors:
                    r = type == LogMessageType.Error ? true : false;
                    break;
                case LogMode.ErrorsAndWarnings:
                    r = type == LogMessageType.Error || type == LogMessageType.Warning ? true : false;
                    break;
            }
            return r;
        }
        private void Work(LogDestiny destiny)
        {
            switch (destiny)
            {
                case LogDestiny.TextFile:
                    new LoggerTextFile().Log(this.messageType.ToString(), message);
                    break;
                case LogDestiny.Console:
                    LoggerConsole lc = new LoggerConsole();
                    lc.onChange += lc_onChange;
                    lc.Log(this.messageType.ToString(), message);
                    break;
                case LogDestiny.DB:
                    new LoggerDB().Log(this.messageType.ToString(), message);
                    break;
            }
        }

        private void lc_onChange(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
        }
    }
}