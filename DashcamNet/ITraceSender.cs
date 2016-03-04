using DashcamNet.Thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashcamNet
{
    public interface ITraceSender
    {
        /**
    * Send span to collector
    *
    * @param span
    */
        void send(Span span);

        /**
         * Send log event to collector
         *
         * @param logEvent
         */
        void send(LogEvent logEvent);
    }
}
