using DashcamNet.Thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashcamNet
{
    public interface ISpan
    {
        /**
    * 关闭span
    */
        void stop();

        /**
         * 检查关闭状态
         */
        bool isStopped();

        /**
         * 获取span开启时间, in milliseconds
         *
         * @return start time in millis
         */
        long getStartTimeMillis();

        /**
         * 获取span关闭时间, in milliseconds
         *
         * @return stop time in millis
         */
        long getStopTimeMillis();


        /**
         * 获取span持续开启的时间
         *
         * @return accumulated duration in millis
         */
        long getAccumulateMillis();

        /**
         * 取span的运行状态
         *
         * @return the running status of the span
         */
        bool isRunning();

        /**
         * span的一个文本描述
         *
         * @return a String descritpion
         */
        String getDescription();

        /**
         * Span id，一个伪随机数
         *
         * @return a span id
         */
        long getSpanId();

        /**
         * 父span， 对于root span则返回null
         *
         * @return parent span
         */
        ISpan getParent();

        /**
         * 和span相关联的trace id，一个伪随机数,
         * 一个trace中的多个span共用同一个trace id
         *
         * @return a trace id associated with this span
         */
        long getTraceId();

        /**
         * 创建当前span的一个子span
         *
         * @param name        span name
         * @param serviceName service name
         * @param spanType    type of the span
         * @return ISpan instance
         */
        ISpan createChild(String name, String serviceName, SpanType spanType, ITrace tracer);

        /**
         * 父span的span id，一个伪随机数，对于根root span则返回ROOT_SPAN_ID
         *
         * @return parent
         */
        long getParentId();

        /**
         * 获得和span相关联的日志，
         * 该属性仅返回一个只读list，如果想在当前span上添加日志，请使用<see cref="ITrace"/>API.
         *
         * @return a list of log events
         */
        List<LogEvent> getLogEvents();

        /**
         * 获得span的类型
         *
         * @return span type
         */
        SpanType getSpanType();

        /**
         * 获得内部 thrift span.
         *
         * @return inner thrift span
         */
        Span getInnerSpan();
    }
}
