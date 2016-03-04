using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashcamNet
{
    public interface ILog
    {
        /**
    * 记录一条DEBUG<see cref="LogLevel.DEBUG"/>级别日志。
    *
    * @param title log title.
    * @param message log message.
    */
        void debug(String title, String message);

        /**
         * 记录一条DEBUG<see cref="LogLevel.DEBUG"/>级别的例外日志。
         *
         * @param title log title.
         * @param throwable a Throwable instance.
         */
        void debug(String title, Exception throwable);

        /**
         * 记录一条DEBUG<see cref="LogLevel.DEBUG"/>级别的日志，附加健值对形式的额外信息。
         *
         * @param title log title
         * @param message log message
         * @param attrs kv pairs
         */
        void debug(String title, String message, Dictionary<String, String> attrs);

        /**
         * 记录一条DEBUG<see cref="LogLevel.DEBUG"/>级别的例外日志，附加健值对形式的额外信息。
         *
         * @param title log title
         * @param throwable a Throwable instance to log
         * @param attrs kv pairs
         */
        void debug(String title, Exception throwable, Dictionary<String, String> attrs);


        /**
         * 记录一条DEBUG<see cref="LogLevel.DEBUG"/>级别的日志。
         *
         * @param message log message.
         */
        void debug(String message);

        /**
         * 记录一条DEBUG<see cref="LogLevel.DEBUG"/>级别的例外日志。
         *
         * @param throwable a Throwable instance.
         */
        void debug(Exception throwable);

        /**
         * 记录一条DEBUG<see cref="LogLevel.DEBUG"/>级别的日志,附加健值对形式的额外信息。
         *
         * @param message log message
         * @param attrs kv pairs
         */
        void debug(String message, Dictionary<String, String> attrs);

        /**
         * 记录一条DEBUG<see cref="LogLevel.DEBUG"/>级别的例外日志,附加健值对形式的额外信息。
         *
         * @param throwable a Throwable instance
         * @param attrs kv pairs
         */
        void debug(Exception throwable, Dictionary<String, String> attrs);


        /**
         * 记录一条ERROR<see cref="LogLevel.ERROR"/>级别日志。
         *
         * @param title log title.
         * @param message log message.
         */
        void error(String title, String message);

        /**
         * 记录一条ERROR<see cref="LogLevel.ERROR"/>级别的例外日志。
         *
         * @param title log title.
         * @param throwable a Throwable instance.
         */
        void error(String title, Exception throwable);

        /**
         * 记录一条ERROR<see cref="LogLevel.ERROR"/>级别的日志, 附加健值对形式的额外信息。
         *
         * @param title log title
         * @param message log message
         * @param attrs kv pairs
         */
        void error(String title, String message, Dictionary<String, String> attrs);

        /**
         * 记录一条ERROR<see cref="LogLevel.ERROR"/>级别的例外日志，附加健值对形式的额外信息。
         *
         * @param title log title
         * @param throwable a Throwable instance to log
         * @param attrs kv pairs
         */
        void error(String title, Exception throwable, Dictionary<String, String> attrs);


        /**
         * 记录一条ERROR<see cref="LogLevel.ERROR"/>级别的日志。
         *
         * @param message log message.
         */
        void error(String message);

        /**
         * 记录一条ERROR<see cref="LogLevel.ERROR"/>级别的例外日志。
         *
         * @param throwable a Throwable instance.
         */
        void error(Exception throwable);

        /**
         * 记录一条ERROR<see cref="LogLevel.ERROR"/>级别的日志, 附加健值对形式的额外信息。
         *
         * @param message log message
         * @param attrs kv pairs
         */
        void error(String message, Dictionary<String, String> attrs);

        /**
         * 记录一条ERROR<see cref="LogLevel.ERROR"/>级别的例外日志,附加健值对形式的额外信息。
         *
         * @param throwable a Throwable instance
         * @param attrs kv pairs
         */
        void error(Exception throwable, Dictionary<String, String> attrs);

        /**
         * 记录一条FATAL<see cref="LogLevel.FATAL"/>级别的日志。
         *
         * @param title log title.
         * @param message log message.
         */
        void fatal(String title, String message);

        /**
         * 记录一条FATAL<see cref="LogLevel.FATAL"/>级别的例外日志。
         *
         * @param title log title.
         * @param throwable a Throwable instance.
         */
        void fatal(String title, Exception throwable);

        /**
         * 记录一条FATAL<see cref="LogLevel.FATAL"/>级别的日志, 附加健值对形式的额外信息。
         *
         * @param title log title
         * @param message log message
         * @param attrs kv pairs
         */
        void fatal(String title, String message, Dictionary<String, String> attrs);

        /**
         * 记录一条FATAL<see cref="LogLevel.FATAL"/>级别的例外日志，附加健值对形式的额外信息。
         *
         * @param title log title
         * @param throwable a Throwable instance to log
         * @param attrs kv pairs
         */
        void fatal(String title, Exception throwable, Dictionary<String, String> attrs);


        /**
         * 记录一条FATAL<see cref="LogLevel.FATAL"/>级别的日志。
         *
         * @param message log message.
         */
        void fatal(String message);

        /**
         * 记录一条FATAL<see cref="LogLevel.FATAL"/>级别的例外日志。
         *
         * @param throwable a Throwable instance.
         */
        void fatal(Exception throwable);

        /**
         * 记录一条FATAL<see cref="LogLevel.FATAL"/>级别的日志，附加健值对形式的额外信息。
         *
         * @param message log message
         * @param attrs kv pairs
         */
        void fatal(String message, Dictionary<String, String> attrs);


        /**
         * 记录一条FATAL<see cref="LogLevel.FATAL"/>级别的例外日志,附加健值对形式的额外信息。
         *
         * @param throwable a Throwable instance
         * @param attrs kv pairs
         */
        void fatal(Exception throwable, Dictionary<String, String> attrs);

        /**
         * 记录一条INFO<see cref="LogLevel.INFO"/>级别的日志。
         *
         * @param title log title.
         * @param message log message.
         */
        void info(String title, String message);

        /**
         * 记录一条INFO<see cref="LogLevel.INFO"/>级别的例外日志。
         *
         * @param title log title.
         * @param throwable a Throwable instance.
         */
        void info(String title, Exception throwable);

        /**
         * 记录一条INFO<see cref="LogLevel.INFO"/>级别的日志，附加健值对形式的额外信息。
         *
         * @param title log title
         * @param message log message
         * @param attrs kv pairs
         */
        void info(String title, String message, Dictionary<String, String> attrs);

        /**
         * 记录一条INFO<see cref="LogLevel.INFO"/>级别的例外日志，附加健值对形式的额外信息。
         *
         * @param title log title
         * @param throwable a Throwable instance to log
         * @param attrs kv pairs
         */
        void info(String title, Exception throwable, Dictionary<String, String> attrs);


        /**
         * 记录一条INFO<see cref="LogLevel.INFO"/>级别的日志。
         *
         * @param message log message.
         */
        void info(String message);

        /**
         * 记录一条INFO<see cref="LogLevel.INFO"/>级别的例外日志。
         *
         * @param throwable a Throwable instance.
         */
        void info(Exception throwable);

        /**
         * 记录一条INFO<see cref="LogLevel.INFO"/>级别的日志,附加健值对形式的额外信息。
         *
         * @param message log message
         * @param attrs kv pairs
         */
        void info(String message, Dictionary<String, String> attrs);

        /**
         * 记录一条INFO<see cref="LogLevel.INFO"/>级别的例外日志,附加健值对形式的额外信息。
         *
         * @param throwable a Throwable instance
         * @param attrs kv pairs
         */
        void info(Exception throwable, Dictionary<String, String> attrs);

        /**
         * 记录一条WARN<see cref="LogLevel.WARN"/>级别的日志。
         *
         * @param title log title.
         * @param message log message.
         */
        void warn(String title, String message);

        /**
         * 记录一条WARN<see cref="LogLevel.WARN"/>级别的例外日志。
         *
         * @param title log title.
         * @param throwable a Throwable instance.
         */
        void warn(String title, Exception throwable);

        /**
         * 记录一条WARN<see cref="LogLevel.WARN"/>级别的日志,附加健值对形式的额外信息。
         *
         * @param title log title
         * @param message log message
         * @param attrs kv pairs
         */
        void warn(String title, String message, Dictionary<String, String> attrs);


        /**
         * 记录一条WARN<see cref="LogLevel.WARN"/>级别的例外日志，附加健值对形式的额外信息。
         *
         * @param title log title
         * @param throwable a Throwable instance to log
         * @param attrs kv pairs
         */
        void warn(String title, Exception throwable, Dictionary<String, String> attrs);


        /**
         * 记录一条WARN<see cref="LogLevel.WARN"/>级别的日志。
         *
         * @param message log message.
         */
        void warn(String message);

        /**
         * 记录一条WARN<see cref="LogLevel.WARN"/>级别的例外日志。
         *
         * @param throwable a Throwable instance.
         */
        void warn(Exception throwable);

        /**
         * 记录一条WARN<see cref="LogLevel.WARN"/>级别的日志,附加健值对形式的额外信息。
         *
         * @param message log message
         * @param attrs kv pairs
         */
        void warn(String message, Dictionary<String, String> attrs);

        /**
         * 记录一条WARN<see cref="LogLevel.WARN"/>级别的例外日志,附加健值对形式的额外信息。
         *
         * @param throwable a Throwable instance
         * @param attrs kv pairs
         */
        void warn(Exception throwable, Dictionary<String, String> attrs);
    }
}
