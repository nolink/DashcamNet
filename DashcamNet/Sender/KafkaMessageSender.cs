using DashcamNet.Common;
using KafkaNet;
using KafkaNet.Model;
using KafkaNet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;
using Thrift.Transport;

namespace DashcamNet.Sender
{
    class KafkaMessageSender : IMessageSender
    {
        private volatile int minInterval = 500;
        Producer producer;

        public KafkaMessageSender(string[] brokerList)
        {
            //.net kafka客户端的丑陋，需要加上http前缀，这里需要注意
            var options = new KafkaOptions(brokerList.Select(x => new Uri(string.Format("http://{0}",x))).ToArray());
            var router = new BrokerRouter(options);
            producer = new Producer(router);
        }

        public void send(Thrift.Chunk chunk)
        {
            send(Constants.MSG_TOPIC, chunk);
        }

        public void send(string topic, Thrift.Chunk chunk)
        {
            using (TMemoryBuffer trans = new TMemoryBuffer())
            using (TProtocol proto = new TBinaryProtocol(trans))
            {
                chunk.Write(proto);

                byte[] data = trans.GetBuffer();
                if (data.Length > 0)
                {
                    Message msg = new Message();
                    msg.Key = Guid.NewGuid().ToByteArray();
                    msg.Value = data;
                    producer.SendMessageAsync(topic, new[] { msg });//.Wait();
                }
            }
        }

        public int getMinInterval()
        {
            return this.minInterval;
        }

        public void close()
        {
            using (producer) { }
        }
    }
}
