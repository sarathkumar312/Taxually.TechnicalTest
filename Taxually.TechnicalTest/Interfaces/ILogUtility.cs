namespace Taxually.TechnicalTest.Interfaces
{
    public interface ILogUtility
    {
        /// <summary>
        /// Method to log the information.
        /// </summary>
        /// <param name="log">Log information.</param>
        void LogInfo(string log);

        /// <summary>
        /// Method to log the exception.
        /// </summary>
        /// <param name="exception">Exception.</param>
        /// <param name="exceptionMessage">The exception message.</param>
        void LogException(Exception exception, string exceptionMessage);
    }
}
