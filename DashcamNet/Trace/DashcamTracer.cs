using DashcamNet.Common;
using DashcamNet.Sender;
using DashcamNet.Thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DashcamNet.Trace
{
    class DashcamTracer : ITrace
    {
        private ITraceSender sender;

        public ITraceSender Sender { get { return sender; } set { sender = value; } }

        [ThreadStatic]
        private static ISpan currentSpan;
        private static long ROOT_SPAN_ID = 0L;
        private String name;

        public DashcamTracer(String name)
        {
            if (String.IsNullOrEmpty(name))
            {
                this.name = "defaultTraceName";
            }
            else
            {
                this.name = name;
            }
            this.sender = new DashcamTraceSender();
        }

        public void log(LogEvent logEvent)
        {
            if (logEvent.Id <= 0)
            {
                logEvent.Id = IdentityUtil.getUniqueID();
            }
            if (logEvent.LogType == null)
            {
                logEvent.LogType = LogType.APP;
            }
            if (logEvent.CreatedTime <= 0)
            {
                logEvent.CreatedTime = DateUtil.CurrentTimeMillis();
            }
            if (logEvent.ThreadId <= 0)
            {
                logEvent.ThreadId = Thread.CurrentThread.ManagedThreadId;
            }
            if (String.IsNullOrEmpty(logEvent.Title))
            {
                logEvent.Title = "NA";
            }
            if (String.IsNullOrEmpty(logEvent.Message))
            {
                logEvent.Message = "NA";
            }
            if (String.IsNullOrEmpty(logEvent.Source))
            {
                logEvent.Source = name;
            }
            if (this.isTracing())
            {
                // attach the log event to current span
                Span innerSpan = currentSpan.getInnerSpan();
                logEvent.TraceId = innerSpan.TraceId;
                logEvent.SpanId = innerSpan.SpanId;

                ((MilliSpan)currentSpan).addLogEvent(logEvent);
            }
            else
            {
                // deliver the logEvent directly if tracing is not enabled.
                deliver(logEvent);
            }
        }

        private void deliver(ISpan span)
        {
            if (sender != null)
            {
                sender.send(span.getInnerSpan());
            }
        }

        private void deliver(LogEvent logEvent)
        {
            if (sender != null)
            {
                sender.send(logEvent);
            }
        }

        public ISpan startSpan(string spanName, string serviceName, Thrift.SpanType spanType, ISampler sampler)
        {
            if (!sampler.next())
            {
                currentSpan = NullSpan.getInstance();
                return currentSpan;
            }
            ISpan parent = currentSpan;
            ISpan root;
            if (parent == null || parent is NullSpan)
            {
                root = new RootMilliSpan(spanName, serviceName, RandomUtil.NextLong(),
                        RandomUtil.NextLong(), ROOT_SPAN_ID, spanType, this);
            }
            else
            {
                root = parent.createChild(spanName, serviceName, spanType, this);
            }
            push(root);

            return root;
        }

        private void push(ISpan span)
        {
            if (span != null)
            {
                currentSpan = span;

                LogEvent logEvent = new LogEvent();
                logEvent.Id = IdentityUtil.getUniqueID();
                logEvent.LogType = spanToLogType(span.getSpanType());
                logEvent.Title = span.getSpanType() + " Trace Span Start";
                logEvent.Message = span.getDescription();
                logEvent.LogLevel = LogLevel.DEBUG;
                logEvent.Source = name;
                logEvent.ThreadId = Thread.CurrentThread.ManagedThreadId;
                logEvent.CreatedTime = DateUtil.CurrentTimeMillis();
                ((MilliSpan)span).addLogEvent(logEvent);
            }
        }

        private LogType spanToLogType(SpanType spanType)
        {
            if (spanType == SpanType.URL)
            {
                return LogType.URL;
            }
            if (spanType == SpanType.SQL)
            {
                return LogType.SQL;
            }
            if (spanType == SpanType.WEB_SERVICE)
            {
                return LogType.WEB_SERVICE;
            }
            if (spanType == SpanType.MEMCACHED)
            {
                return LogType.MEMCACHED;
            }
            return LogType.OTHER;
        }

        public ISpan startSpan(string spanName, string serviceName, Thrift.SpanType spanType)
        {
            return this.startSpan(spanName, serviceName, spanType, AlwaysSampler.getInstance());
        }

        public bool isTracing()
        {
            return currentSpan != null && !(currentSpan is NullSpan);
        }

        public void clear()
        {
            int i = 0;
            while (currentSpan != null && !(currentSpan is NullSpan))
            {
                i++;
                if (i > 50)
                {
                    log(LogType.OTHER, LogLevel.WARN, "possible unlimited loop in unfinished span handling");
                    break; // prevent possible unlimited loop
                }
                // deliver unfinished span
                ISpan currSpan = currentSpan;
                currSpan.getInnerSpan().StopTime = DateUtil.CurrentTimeMillis(); // mark the span as stopped
                currSpan.getInnerSpan().Unfinished = true;
                deliver(currSpan);
                currentSpan = currSpan.getParent();
            }

            currentSpan = null;
        }

        public ISpan continueSpan(string spanName, string serviceName, long traceId, long parentId, Thrift.SpanType spanType)
        {
            ISpan rootSpan = new RootMilliSpan(spanName, serviceName, traceId, RandomUtil.NextLong(), parentId, spanType, this);
            push(rootSpan);
            return rootSpan;
        }

        public ISpan getCurrentSpan()
        {
            return currentSpan;
        }

        private void log(LogType type, String title, String message, LogLevel logLevel, Dictionary<String, String> attrs)
        {
            LogEvent logEvent = new LogEvent();
            logEvent.Id = IdentityUtil.getUniqueID();
            logEvent.LogType = type;
            logEvent.Title = title;

            logEvent.Message = message;
            logEvent.Source = name;
            logEvent.Attributes = attrs;
            logEvent.LogLevel = logLevel;

            log(logEvent);
        }

        public void log(Thrift.LogType type, Thrift.LogLevel level, string title, string message)
        {
            this.log(type, title, message, level, null);
        }

        public void log(Thrift.LogType type, Thrift.LogLevel level, string title, Exception t)
        {
            String msg = "NullThrowable";
            if (t != null)
            {
                msg = t.ToString();
            }
            this.log(type, title, msg, level, null);
        }

        public void log(Thrift.LogType type, Thrift.LogLevel level, string title, string message, Dictionary<string, string> attrs)
        {
            this.log(type, title, message, level, attrs);
        }

        public void log(Thrift.LogType type, Thrift.LogLevel level, string title, Exception throwable, Dictionary<string, string> attrs)
        {
            String msg = "NullThrowable";
            if (throwable != null)
            {
                msg = throwable.ToString();
            }
            this.log(type, title, msg, level, attrs);
        }

        public void log(Thrift.LogType type, Thrift.LogLevel level, string message)
        {
            this.log(type, null, message, level, null);
        }

        public void log(Thrift.LogType type, Thrift.LogLevel level, Exception t)
        {
            String msg = "NullThrowable";
            if (t != null)
            {
                msg = t.ToString();
            }
            this.log(type, null, msg, level, null);
        }

        public void log(Thrift.LogType type, Thrift.LogLevel level, string message, Dictionary<string, string> attrs)
        {
            this.log(type, null, message, level, attrs);
        }

        public void log(Thrift.LogType type, Thrift.LogLevel level, Exception throwable, Dictionary<string, string> attrs)
        {
            String msg = "NullThrowable";
            if (throwable != null)
            {
                msg = throwable.ToString();
            }
            this.log(type, null, msg, level, attrs);
        }

        // check if span is on parent path of currSpan
        private bool isOnParentPath(ISpan currSpan, ISpan span)
        {
            if (span == null)
                return false;
            int i = 0;
            while (currSpan != span && currSpan != null)
            {
                i++;
                if (i > 50)
                {
                    log(LogType.OTHER, LogLevel.WARN, "possible unlimited loop in unfinished span handling.");
                    break; // prevent possible unlimited loop
                }
                currSpan = currSpan.getParent();
            }

            if (currSpan == span)
                return true;

            return false;
        }

        internal void pop(ISpan span)
        {
            if (span != null)
            {
                if (span != currentSpan)
                {
                    log(LogType.OTHER, LogLevel.WARN, "Stopped span: " + span
                            + " was not the current span. current span is: "
                            + currentSpan);
                    if (this.isOnParentPath(currentSpan, span))
                    {
                        while (currentSpan != span)
                        {
                            // deliver unfinished span
                            ISpan currSpan = currentSpan;
                            currSpan.getInnerSpan().StopTime = DateUtil.CurrentTimeMillis();
                            currSpan.getInnerSpan().Unfinished = true;
                            deliver(currSpan);
                            currentSpan = currSpan.getParent();
                        }
                    }
                }

                LogEvent logEvent = new LogEvent();
                logEvent.Id = IdentityUtil.getUniqueID();
                logEvent.LogType = spanToLogType(span.getSpanType());
                logEvent.Title = span.getSpanType() + " Trace Span Stop";
                logEvent.Message = span.getDescription();
                logEvent.LogLevel = LogLevel.DEBUG;
                logEvent.Source = name;
                logEvent.ThreadId = Thread.CurrentThread.ManagedThreadId;
                logEvent.CreatedTime = DateUtil.CurrentTimeMillis();
                ((MilliSpan)span).addLogEvent(logEvent);

                currentSpan = span.getParent();

                deliver(span);
            }
            else
            {
                currentSpan = null;
            }
        }
    }
}
