using DashcamNet.Common;
using DashcamNet.Thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashcamNet.Sender
{
    class DashcamTraceSender : ITraceSender
    {
        public void send(Thrift.Span span)
        {
            // if no broker list configured, just ignore this event
            if (String.IsNullOrEmpty(LogConfig.GetInstance().BrokerList))
            {
                return;
            }
            // lazy initialization
            MessageBuffer messageConsumer = AgentManager.GetInstance().MsgBuffer;

            // switch on or off logging by global setting
            bool traceEnabled = LogConfig.GetInstance().TraceEnabled;

            if (traceEnabled && messageConsumer != null)
            {
                filterLogEventByLevel(span);
                foreach (LogEvent logEvent in span.LogEvents)
                {
                    LogEventUtil.truncateLogSize(logEvent, LogConfig.GetInstance().MaxMessageSize);
                }
                messageConsumer.Put(span);
            }
            else
            { // APP log should be sent out since it is a separate log type
                foreach (LogEvent logEvent in span.LogEvents)
                {
                    if (logEvent.LogType == LogType.APP)
                    {
                        // truncate log event size
                        LogEventUtil.truncateLogSize(logEvent, LogConfig.GetInstance().MaxMessageSize);

                        // remove trace id since tracing is disabled
                        logEvent.TraceId = 0;
                        messageConsumer.Put(logEvent);
                    }
                }
            }
        }

        public void send(Thrift.LogEvent logEvent)
        {
            // if no broker list configured, just ignore this event
            if (String.IsNullOrEmpty(LogConfig.GetInstance().BrokerList))
            {
                return;
            }

            // lazy initialization
            MessageBuffer messageConsumer = AgentManager.GetInstance().MsgBuffer;

            // switch on or off logging by global setting
            bool traceEnabled = LogConfig.GetInstance().TraceEnabled;
            if (logEvent.LogType != LogType.APP)
            {
                if (traceEnabled)
                {
                    if (!this.isLogLevelEnabled(logEvent.LogLevel))
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }

            if (!isLogLevelEnabled(logEvent.LogLevel))
            {
                return;
            }

            // truncate log event size
            LogEventUtil.truncateLogSize(logEvent, LogConfig.GetInstance().MaxMessageSize);
            messageConsumer.Put(logEvent);
        }

        private void filterLogEventByLevel(Span span)
        {
            if (span.LogEvents != null && span.LogEvents.Count > 0)
            {
                HashSet<LogEvent> tobeRemovedList = new HashSet<LogEvent>();
                for (int i = 0; i < span.LogEvents.Count; i++)
                {
                    LogEvent logEvent = span.LogEvents[i];
                    // app log has already been filtered by app logger, so we don't filter them again here
                    if (logEvent.LogType != LogType.APP &&
                            !isLogLevelEnabled(logEvent.LogLevel))
                    {
                        span.LogEvents.RemoveAt(i);
                    }
                }
            }
        }

        private bool isLogLevelEnabled(LogLevel level)
        {
            return level >= LogConfig.GetInstance().Level;
        }

    }
}
