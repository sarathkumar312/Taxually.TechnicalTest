using NLog;
using Taxually.TechnicalTest.Interfaces;
using LogLevel = NLog.LogLevel;

namespace Taxually.TechnicalTest.Utilities
{
        /// <summary>
        /// The log utility class.
        /// </summary>
        public class LogUtility : ILogUtility
        {
            /// <summary>
            /// The logger.
            /// </summary>
            private static readonly Logger LoggerInternal = LogManager.GetCurrentClassLogger();

            /// <summary>
            /// Method to log the information.
            /// </summary>
            /// <param name="log">The Log Message.</param>
            public void LogInfo(string log)
            {
                LoggerInternal.Log(LogLevel.Info, log);
            }

        /// <summary>
        /// Method to log the exception.
        /// </summary>
        /// <param name="exception">Exception.</param>
        /// <param name="exceptionMessage">The exception message.</param>
        public void LogException(Exception exception, string exceptionMessage)
        {
            LoggerInternal.Log(LogLevel.Error, exception, exceptionMessage, null);
        }
    }
}
