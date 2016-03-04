using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashcamNet.Common
{
    class Constants
    {
        public const int APPID = 9011;
        /**
     * Raw log kafka topic
     */
        public const String MSG_TOPIC = "com.dcf.iqunxing.fx.dashcam";

        /**
         * Environment(hostName, hostIp, env, envGroup) topic
         */
        public const String ENV_TOPIC = "com.dcf.iqunxing.fx.dashcam.env";
    }
}
