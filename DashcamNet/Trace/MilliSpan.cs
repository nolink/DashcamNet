using ClutchNet;
using DashcamNet.Common;
using DashcamNet.Thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DashcamNet.Trace
{
    class MilliSpan : ISpan
    {

        private Span innerSpan;
        private ISpan parent;
        private DashcamTracer tracer;

        public MilliSpan(String name, String serviceName, long id, ISpan parent, SpanType spanType, DashcamTracer tracer)
        {
            this.innerSpan = new Span();
            if (String.IsNullOrEmpty(name))
            {
                this.innerSpan.Name="NoNameSpan";
            }
            else
            {
                this.innerSpan.Name=name;
            }
            if (String.IsNullOrEmpty(serviceName))
            {
                this.innerSpan.ServiceName="NoNameService";
            }
            else
            {
                this.innerSpan.ServiceName=serviceName;
            }
            this.innerSpan.SpanId=id;
            this.innerSpan.AppId=Configuration.GetAppId()+"";
            this.innerSpan.SpanType=spanType;
            this.parent = parent;
            this.innerSpan.ParentId=getParentId();
            this.innerSpan.TraceId=getTraceId();
            this.innerSpan.StartTime = DateUtil.CurrentTimeMillis();
            this.innerSpan.StopTime=0;
            this.innerSpan.HostIp=HostUtil.GetHostIp();
            this.innerSpan.HostName=HostUtil.GetHostName();
            this.innerSpan.Unfinished=false;
            this.innerSpan.ThreadId = Thread.CurrentThread.ManagedThreadId;

            this.tracer = tracer;
        }

        public void stop()
        {
            if (this.isStopped())
            {
                // no effect, has been stopped
                return;
            }
            this.innerSpan.StopTime = DateUtil.CurrentTimeMillis();
            tracer.pop(this);
        }

        public bool isStopped()
        {
            return this.innerSpan.StopTime != 0L;
        }

        public long getStartTimeMillis()
        {
            return this.getInnerSpan().StartTime;
        }

        public long getStopTimeMillis()
        {
            return this.getInnerSpan().StopTime;
        }

        public long getAccumulateMillis()
        {
            if (this.innerSpan.StartTime == 0)
            {
                return 0;
            }
            if (this.innerSpan.StopTime > 0)
            {
                return this.innerSpan.StopTime - this.innerSpan.StartTime;
            }
            return DateUtil.CurrentTimeMillis() - this.innerSpan.StartTime;
        }

        public bool isRunning()
        {
            return this.innerSpan.StartTime != 0L && this.innerSpan.StopTime == 0L;
        }

        public string getDescription()
        {
            return "[" + this.innerSpan.ServiceName + " : " + this.innerSpan.Name + "]";
        }

        public long getSpanId()
        {
            return this.innerSpan.SpanId;
        }

        public ISpan getParent()
        {
            return parent;
        }

        public long getTraceId()
        {
            return this.parent.getTraceId();
        }

        public ISpan createChild(string name, string serviceName, Thrift.SpanType spanType, ITrace tracer)
        {
            return new MilliSpan(name, serviceName, RandomUtil.NextLong(), this, spanType, (DashcamTracer)tracer);
        }

        public long getParentId()
        {
            return this.parent.getSpanId();
        }

        public List<Thrift.LogEvent> getLogEvents()
        {
            return this.innerSpan.LogEvents;
        }

        public void addLogEvent(LogEvent logEvent)
        {
            if (logEvent == null) return;
            logEvent.TraceId=this.getTraceId();
            this.innerSpan.LogEvents.Add(logEvent);
        }

        public Thrift.SpanType getSpanType()
        {
            return this.innerSpan.SpanType;
        }

        public Span getInnerSpan()
        {
            return this.innerSpan;
        }
    }
}
