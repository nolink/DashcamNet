using DashcamNet;
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
            ILog log = LogManager.GetLogger("test");

            log.info("this is a test");

            System.Threading.Thread.Sleep(1000);

            log.info("this is another test");

            Console.Read();
        }
    }
}
