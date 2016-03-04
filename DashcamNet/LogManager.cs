using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using DashcamNet.Log;
using DashcamNet.Common;
using DashcamNet.Sender;

namespace DashcamNet
{
    public class LogManager
    {
        private LogManager() { }

        private static ConcurrentDictionary<string, ILog> _loggers = new ConcurrentDictionary<string, ILog>();

        public static ILog GetLogger(string name)
        {
            string loggerName = name;
            if (string.IsNullOrEmpty(loggerName))
            {
                loggerName = "defaultLogger";
            }
            return _loggers.GetOrAdd(loggerName, (innerLoggerName) => {
                if (string.IsNullOrEmpty(LogConfig.GetInstance().BrokerList))
                {
                    return new EmptyLogger();
                }
                else
                {
                    return new DashcamLogger(innerLoggerName, new DashcamLogSender(TraceManager.GetTracer(innerLoggerName)));
                }
            });
        }

    }
}
