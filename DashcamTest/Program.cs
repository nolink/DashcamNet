using DashcamNet;
using DashcamNet.Thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashcamTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //ILog log = LogManager.GetLogger("test");

            //log.info("this is a test");

            //System.Threading.Thread.Sleep(1000);

            //log.info("this is another test");

            //ITrace trace = TraceManager.GetTracer("test_t");

            //ISpan span = trace.startSpan("test", "fuck", DashcamNet.Thrift.SpanType.WEB_SERVICE);
            //trace.log(LogType.WEB_SERVICE, LogLevel.INFO, "trace test");
            //trace.log(LogType.WEB_SERVICE, LogLevel.INFO, "trace test2");
            //span.stop();
            //trace.clear();

            ILog log = LogManager.GetLogger("test");

            int[] arr = { 1, 2, 3, 4, 5 };

            Parallel.ForEach(arr, a =>
            {
                for (int i = 0; i < 10000; i++)
                {
                    var msg = a + "  " + i.ToString();
                    log.error(msg);
                    Console.Write(msg);
                }
            });

            Console.Read();
        }
    }
}
