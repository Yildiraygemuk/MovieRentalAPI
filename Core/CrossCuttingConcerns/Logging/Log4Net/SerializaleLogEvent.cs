using log4net.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Logging.Log4Net
{
    [Serializable]
    public class SerializaleLogEvent
    {
        private LoggingEvent _loggingEvent;
        public SerializaleLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }
        public object Message => _loggingEvent.MessageObject;
    }
}
