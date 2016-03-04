using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashcamNet.Trace
{
    class AlwaysSampler : ISampler
    {
        private static class AlwaysSamplerHolder
        {
            public static AlwaysSampler instance = new AlwaysSampler();
        }

        public static AlwaysSampler getInstance()
        {
            return AlwaysSamplerHolder.instance;
        }

        private AlwaysSampler()
        {
        }


        public bool next()
        {
            return true;
        }
    }
}
