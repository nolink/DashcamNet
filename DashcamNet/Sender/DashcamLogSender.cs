using DashcamNet.Common;
using DashcamNet.Thrift;
using DashcamNet.Trace;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashcamNet.Sender
{
    class DashcamLogSender : ILogSender
    {
        private ITrace _tracer;

        public DashcamLogSender(ITrace tracer)
        {
            this._tracer = tracer;
        }

        private bool isLogLevelEnabled(LogLevel level)
        {
            return level >= LogConfig.GetInstance().Level;
        }

        public void send(LogEvent logEvent)
        {
            if (String.IsNullOrEmpty(LogConfig.GetInstance().BrokerList))
            {
                return;
            }
            // switch on or off logging by global setting
            if (LogConfig.GetInstance().AppLogEnabled && isLogLevelEnabled(logEvent.LogLevel))
            {
                ((DashcamTracer)_tracer).log(logEvent);
            }
        }
    }
}
