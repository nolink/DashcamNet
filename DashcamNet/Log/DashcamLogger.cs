using DashcamNet.Common;
using DashcamNet.Thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DashcamNet.Log
{
    class DashcamLogger : ILog
    {
        private String _logName = "";
        private ILogSender _logSender;

        public DashcamLogger(String logName, ILogSender sender)
        {
            if (String.IsNullOrEmpty(logName))
            {
                this._logName = "defaultLogName";
            }
            else
            {
                this._logName = logName;
            }

            this._logSender = sender;
        }

        private void writeLog(LogLevel logLevel, String title, String message,
            Exception throwable, Dictionary<String, String> attrs)
        {
            LogEvent logEvent = new LogEvent();
            logEvent.Id = IdentityUtil.getUniqueID();
            logEvent.LogLevel = logLevel;
            logEvent.LogType = LogType.APP;
            logEvent.CreatedTime = DateUtil.CurrentTimeMillis();
            logEvent.Source = this._logName;
            logEvent.ThreadId = Thread.CurrentThread.ManagedThreadId;
            logEvent.Title = title;
            if (String.IsNullOrEmpty(title))
            {
                logEvent.Title = "NA";
            }
            if (message != null)
            {
                logEvent.Message = message;
            }
            if (throwable != null)
            {
                if (logEvent.Title.Equals("NA"))
                {
                    logEvent.Title = throwable.Message;
                }
                logEvent.Message = throwable.ToString();
            }
            if (logEvent.Message == null)
            {
                logEvent.Message = "";
            }
            logEvent.Attributes = attrs;
            if (this._logSender != null)
            {
                _logSender.send(logEvent);
            }
        }


        public void debug(string title, string message)
        {
            this.writeLog(LogLevel.DEBUG, title, message, null, null);
        }

        public void debug(string title, Exception throwable)
        {
            this.writeLog(LogLevel.DEBUG, title, null, throwable, null);
        }

        public void debug(string title, string message, Dictionary<string, string> attrs)
        {
            this.writeLog(LogLevel.DEBUG, title, message, null, attrs);
        }

        public void debug(string title, Exception throwable, Dictionary<string, string> attrs)
        {
            this.writeLog(LogLevel.DEBUG, title, null, throwable, attrs);
        }

        public void debug(string message)
        {
            this.writeLog(LogLevel.DEBUG, null, message, null, null);
        }

        public void debug(Exception throwable)
        {
            this.writeLog(LogLevel.DEBUG, null, null, throwable, null);
        }

        public void debug(string message, Dictionary<string, string> attrs)
        {
            this.writeLog(LogLevel.DEBUG, null, message, null, attrs);
        }

        public void debug(Exception throwable, Dictionary<string, string> attrs)
        {
            this.writeLog(LogLevel.DEBUG, null, null, throwable, attrs);
        }

        public void error(string title, string message)
        {
            this.writeLog(LogLevel.ERROR, title, message, null, null);
        }

        public void error(string title, Exception throwable)
        {
            this.writeLog(LogLevel.ERROR, title, null, throwable, null);
        }

        public void error(string title, string message, Dictionary<string, string> attrs)
        {
            this.writeLog(LogLevel.ERROR, title, message, null, attrs);
        }

        public void error(string title, Exception throwable, Dictionary<string, string> attrs)
        {
            this.writeLog(LogLevel.ERROR, title, null, throwable, attrs);
        }

        public void error(string message)
        {
            this.writeLog(LogLevel.ERROR, null, message, null, null);
        }

        public void error(Exception throwable)
        {
            this.writeLog(LogLevel.ERROR, null, null, throwable, null);
        }

        public void error(string message, Dictionary<string, string> attrs)
        {
            this.writeLog(LogLevel.ERROR, null, message, null, attrs);
        }

        public void error(Exception throwable, Dictionary<string, string> attrs)
        {
            this.writeLog(LogLevel.ERROR, null, null, throwable, attrs);
        }

        public void fatal(string title, string message)
        {
            this.writeLog(LogLevel.FATAL, title, message, null, null);
        }

        public void fatal(string title, Exception throwable)
        {
            this.writeLog(LogLevel.FATAL, title, null, throwable, null);
        }

        public void fatal(string title, string message, Dictionary<string, string> attrs)
        {
            this.writeLog(LogLevel.FATAL, title, message, null, attrs);
        }

        public void fatal(string title, Exception throwable, Dictionary<string, string> attrs)
        {
            this.writeLog(LogLevel.FATAL, null, null, throwable, attrs);
        }

        public void fatal(string message)
        {
            this.writeLog(LogLevel.FATAL, null, message, null, null);
        }

        public void fatal(Exception throwable)
        {
            this.writeLog(LogLevel.FATAL, null, null, throwable, null);
        }

        public void fatal(string message, Dictionary<string, string> attrs)
        {
            this.writeLog(LogLevel.FATAL, null, message, null, attrs);
        }

        public void fatal(Exception throwable, Dictionary<string, string> attrs)
        {
            this.writeLog(LogLevel.FATAL, null, null, throwable, attrs);
        }

        public void info(string title, string message)
        {
            this.writeLog(LogLevel.INFO, title, message, null, null);
        }

        public void info(string title, Exception throwable)
        {
            this.writeLog(LogLevel.INFO, title, null, throwable, null);
        }

        public void info(string title, string message, Dictionary<string, string> attrs)
        {
            this.writeLog(LogLevel.INFO, title, message, null, attrs);
        }

        public void info(string title, Exception throwable, Dictionary<string, string> attrs)
        {
            this.writeLog(LogLevel.INFO, null, null, throwable, attrs);
        }

        public void info(string message)
        {
            this.writeLog(LogLevel.INFO, null, message, null, null);
        }

        public void info(Exception throwable)
        {
            this.writeLog(LogLevel.INFO, null, null, throwable, null);
        }

        public void info(string message, Dictionary<string, string> attrs)
        {
            this.writeLog(LogLevel.INFO, null, message, null, attrs);
        }

        public void info(Exception throwable, Dictionary<string, string> attrs)
        {
            this.writeLog(LogLevel.INFO, null, null, throwable, attrs);
        }

        public void warn(string title, string message)
        {
            this.writeLog(LogLevel.WARN, title, message, null, null);
        }

        public void warn(string title, Exception throwable)
        {
            this.writeLog(LogLevel.WARN, title, null, throwable, null);
        }

        public void warn(string title, string message, Dictionary<string, string> attrs)
        {
            this.writeLog(LogLevel.WARN, title, message, null, attrs);
        }

        public void warn(string title, Exception throwable, Dictionary<string, string> attrs)
        {
            this.writeLog(LogLevel.WARN, title, null, throwable, attrs);
        }

        public void warn(string message)
        {
            this.writeLog(LogLevel.WARN, null, message, null, null);
        }

        public void warn(Exception throwable)
        {
            this.writeLog(LogLevel.WARN, null, null, throwable, null);
        }

        public void warn(string message, Dictionary<string, string> attrs)
        {
            this.writeLog(LogLevel.WARN, null, message, null, attrs);
        }

        public void warn(Exception throwable, Dictionary<string, string> attrs)
        {
            this.writeLog(LogLevel.WARN, null, null, throwable, attrs);
        }
    }
}
