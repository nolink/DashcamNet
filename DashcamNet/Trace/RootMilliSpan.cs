using DashcamNet.Thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashcamNet.Trace
{
    class RootMilliSpan : MilliSpan
    {
        private long traceId;
        private long parentId;

        public RootMilliSpan(String name, String serviceName, long traceId, long spanId, long parentId, SpanType spanType, DashcamTracer tracer)
            : base(name, serviceName, spanId, null, spanType, tracer)    
        {
            this.traceId = traceId;
            this.getInnerSpan().TraceId = traceId;
            this.parentId = parentId;
            this.getInnerSpan().ParentId = parentId;
        }

        public long getTraceId()
        {
            return traceId;
        }

        public long getParentId()
        {
            return parentId;
        }
    }
}
