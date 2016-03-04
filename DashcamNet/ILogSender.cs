using DashcamNet.Thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashcamNet
{
    public interface ILogSender
    {
        /// <summary>
        /// Send log event
        /// </summary>
        /// <param name="logEvent"></param>
        void send(LogEvent logEvent);
    }
}
