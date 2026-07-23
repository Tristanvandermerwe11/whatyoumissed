namespace EventLoggerActivity
{
    class EventLogger : IDisposable
    {
        public delegate void LogEvent(string eventDetails);
        private LogEvent log;

        public EventLogger(LogEvent log)
        {
            this.log = log;
        }

        public void Log(string eventDetails)
        {
            log(eventDetails);
        }

        public void Dispose()
        {
            log = null;
            Console.WriteLine("EventLogger disposed");       
        }
    }
}