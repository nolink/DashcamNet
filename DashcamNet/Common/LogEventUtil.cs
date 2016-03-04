using DashcamNet.Thrift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashcamNet.Common
{
    class LogEventUtil
    {
        private const int MAX_TITLE_SIZE = 200;
        private const int MAX_KEY_SIZE = 32;
        private const int MAX_VALUE_SIZE = 2 * 1024; // 2K
        private const int MAX_ADDINFO_SIZE = 10; // 10个k/v pair

        private static String truncate(String value, int maxLength)
        {
            if (String.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }

        public static void truncateLogSize(LogEvent logEvent, int size)
        {
            int maxMessageSize = size * 1024;
            logEvent.Title = truncate(logEvent.Title, MAX_TITLE_SIZE);
            logEvent.Message = truncate(logEvent.Message, maxMessageSize);

            if (logEvent.Attributes != null && logEvent.Attributes.Count > 0)
            {
                Dictionary<String, String> attrs = new Dictionary<String, String>();
                int i = 0;
                foreach (String key in logEvent.Attributes.Keys)
                {
                    i++;
                    if (i > MAX_ADDINFO_SIZE)
                    {
                        break;
                    }
                    String k = truncate(key, MAX_KEY_SIZE);
                    String v = logEvent.Attributes[key];
                    v = truncate(v, MAX_VALUE_SIZE);
                    attrs.Add(k, v);
                }
                logEvent.Attributes = attrs;
            }
        }
    }
}
