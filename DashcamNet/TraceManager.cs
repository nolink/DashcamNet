using DashcamNet.Trace;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashcamNet
{
    public class TraceManager
    {
        private TraceManager() { }

        private static ConcurrentDictionary<string, ITrace> _tracers = new ConcurrentDictionary<string, ITrace>();

        public static ITrace GetTracer(string name)
        {
            string loggerName = name;
            if (string.IsNullOrEmpty(loggerName))
            {
                loggerName = "defaultTrace";
            }
            return _tracers.GetOrAdd(loggerName, (innerLoggerName) => { return new DashcamTracer(innerLoggerName); });
        }

    }
}
