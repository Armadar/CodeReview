using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Belatrix
{
    interface ILogger
    {
       void Log(string messageType,string message);
    }
}