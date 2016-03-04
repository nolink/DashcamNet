using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClutchNet;
using DashcamNet.Thrift;

namespace DashcamNet.Common
{
    class LogConfig
    {
        private volatile string brokerList = "";
        private volatile LogLevel level = LogLevel.INFO;
        private volatile bool appLogEnabled = true;
        private volatile bool traceEnabled = true;
        private volatile bool metricEnabled = false;
        private volatile short maxMessageSize = 32; //32K
        private volatile int queueSize = 100000;
        private volatile int chunkSize = 50;
        private volatile int consumerCount = 2;

        private LogConfig()
        {
            brokerList = Configuration.GetWithAppId(Constants.APPID, "dashcam.agent.kafka.brokerList", "kafka1.s1.np.fx.dcfservice.com:9092,kafka2.s1.np.fx.dcfservice.com:9092,kafka3.s1.np.fx.dcfservice.com:9092");
            level = (LogLevel)Enum.Parse(typeof(LogLevel), Configuration.Get("dashcam.agent.log.level","INFO"), true);
            appLogEnabled = Boolean.Parse(Configuration.Get("dashcam.agent.log.enable", "true"));
            traceEnabled = Boolean.Parse(Configuration.Get("dashcam.agent.trace.enable", "true"));
            metricEnabled = Boolean.Parse(Configuration.Get("dashcam.agent.metrics,enable", "false"));
            maxMessageSize = short.Parse(Configuration.Get("dashcam.agent.max.message.size", "32"));
            queueSize = int.Parse(Configuration.Get("dashcam.agent.consumer.queue.size", "100000"));
            chunkSize = int.Parse(Configuration.Get("dashcam.agent.chunk.size", "50"));
            consumerCount = int.Parse(Configuration.Get("dashcam.agent.consumer.count", "2"));
        }

        private static LogConfig _instance = new LogConfig();
        public static LogConfig GetInstance()
        {
            return _instance;
        }

        public string BrokerList { get { return brokerList; } }
        public LogLevel Level { get { return level; } }
        public bool AppLogEnabled { get { return appLogEnabled; } }
        public bool TraceEnabled { get { return traceEnabled; } }
        public bool MetricEnabled { get { return metricEnabled; } }
        public short MaxMessageSize { get { return maxMessageSize; } }
        public int QueueSize { get { return queueSize; } }
        public int ChunkSize { get { return chunkSize; } }
        public int ConsumerCount { get { return consumerCount; } }

    }
}
