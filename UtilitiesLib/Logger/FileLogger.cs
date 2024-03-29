using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UtilitiesLib.Logger
{
    public class FileLogger
    {
        public void WriteToFile(string msg)
        {
            string fileName = @"C:\Blackjack\LoggerFiles";

            using (StreamWriter writer = new StreamWriter(fileName))
            {
                Logger.LogMessage(msg);
            }
            
        }
    }
}
