using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesLib.Logger
{
    public static class Logger
    {
        public static Action<string> WriteMessage;
        //public delegate void WriteMessage(string message);
        public static void LogMessage(string msg)
        {
            WriteMessage(msg);
        }
    }
}
