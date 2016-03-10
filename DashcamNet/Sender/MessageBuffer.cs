using DashcamNet.Common;
using DashcamNet.Thrift;
using KafkaNet.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Thrift.Protocol;

namespace DashcamNet.Sender
{
    public class MessageBuffer
    {

        private AsyncCollection<TBase> collection = new AsyncCollection<TBase>();

        private IMessageSender sender = null;

        private ChunkBuilder buildChunk = null;

        private int chunkSize;
        private long start = 0;

        public MessageBuffer(int queueSize, int chunkSize, IMessageSender sender)
        {
            this.chunkSize = chunkSize;
            this.sender = sender;
            this.buildChunk = new ChunkBuilder();
            this.start = DateUtil.CurrentTimeMillis();
            var task = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    var now = DateUtil.CurrentTimeMillis();
                    if (collection.Count > chunkSize || (collection.Count > 0 && now - start >= sender.getMinInterval()))
                    {
                        collection.DrainAndApply((tmpBase) =>
                        {
                            buildChunk.putMsg(tmpBase);
                        });
                        sender.send(buildChunk.getChunk());
                        buildChunk.clear();
                        this.start = now;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(10);
                    }
                }
            }, TaskCreationOptions.LongRunning);
        }

        public void Put(TBase tbase)
        {
            collection.Add(tbase);
        }

    }
}
