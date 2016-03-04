using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DashcamNet.Common
{
    class IdentityUtil
    {

        private static long logid = 0L;

        public static long getUniqueID()
        {
            return (DateUtil.CurrentTimeMillis() << 8)
                    | (Interlocked.Increment(ref logid) & 2 ^ 8 - 1);
        }
    }
}
