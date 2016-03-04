using DashcamNet.Thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashcamNet.Trace
{
    class NullSpan : ISpan
    {
        private static NullSpan instance = new NullSpan();

        // No need to ever have more than one NullSpan.
        public static NullSpan getInstance()
        {
            return instance;
        }

        private NullSpan()
        {
        }

        public void stop()
        {

        }

        public bool isStopped()
        {
            return false;
        }

        public long getStartTimeMillis()
        {
            return 0;
        }

        public long getStopTimeMillis()
        {
            return 0;
        }

        public long getAccumulateMillis()
        {
            return 0;
        }

        public bool isRunning()
        {
            return false;
        }

        public string getDescription()
        {
            return "NullSpan";
        }

        public long getSpanId()
        {
            return -1;
        }

        public ISpan getParent()
        {
            return null;
        }

        public long getTraceId()
        {
            return -1;
        }

        public ISpan createChild(string name, string serviceName, Thrift.SpanType spanType, ITrace tracer)
        {
            return this;
        }

        public long getParentId()
        {
            return -1;
        }

        public List<Thrift.LogEvent> getLogEvents()
        {
            return new List<LogEvent>();
        }

        public Thrift.SpanType getSpanType()
        {
            return SpanType.OTHER;
        }

        public Thrift.Span getInnerSpan()
        {
            return null;
        }
    }
}
