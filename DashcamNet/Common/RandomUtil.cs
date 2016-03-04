using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashcamNet.Common
{
    class RandomUtil
    {
        private static Random rand = new Random();

        public static long NextLong()
        {
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);

            return Math.Abs(longRand);
        }
    }
}
