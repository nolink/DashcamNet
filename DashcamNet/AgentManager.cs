using ClutchNet;
using DashcamNet.Common;
using DashcamNet.Sender;
using DashcamNet.Thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashcamNet
{
    public class AgentManager
    {
        private LogConfig logConfig = LogConfig.GetInstance();

        private IMessageSender sender = null;
        private MessageBuffer msgBuffer = null;

        private static AgentManager _instance = new AgentManager();
        private AgentManager()
        {
            this.sender = new KafkaMessageSender(logConfig.BrokerList.Split(','));
            msgBuffer = new MessageBuffer(logConfig.QueueSize, logConfig.ChunkSize, this.sender);

            Chunk chunk = new Chunk();
            chunk.EnvGroup=Configuration.GetEnvironmentGroup();
            chunk.Env=Configuration.GetEnvironment();
            chunk.HostIp=HostUtil.GetHostIp();
            chunk.HostName=HostUtil.GetHostName();
            chunk.AppId = Configuration.GetAppId();
            chunk.LogEvents=new List<LogEvent>();
            chunk.Metrics=new List<MetricEvent>();
            chunk.Spans=new List<Span>();
            chunk.Events=new List<Event>();

            sender.send(Constants.ENV_TOPIC, chunk);
        }
        public static AgentManager GetInstance()
        {
            return _instance;
        }

        public MessageBuffer MsgBuffer { get { return msgBuffer; } }

    }
}
