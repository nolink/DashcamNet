using DashcamNet.Thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashcamNet
{
    public interface IMessageSender
    {
        /**
         * Send the chuck message to remote service(eg. kafka brokers)
         * @param chunk
         */
        void send(Chunk chunk);

        /**
         *  Send the chuck message to remote service(eg. kafka brokers) with specified topic
         * @param topic
         * @param chunk
         */
        void send(String topic, Chunk chunk);

        /**
         * Get the min send time interval
         * @return time(ms)
         */
        int getMinInterval();

        /**
         * Release resource
         */
        void close();
    }

}
