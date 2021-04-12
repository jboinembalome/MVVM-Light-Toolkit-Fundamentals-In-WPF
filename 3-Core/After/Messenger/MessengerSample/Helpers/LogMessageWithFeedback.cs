using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerSample.Helpers
{
    public class LogMessageWithFeedback : LogMessage
    {
        public Action<bool> Feedback
        {
            get;
            private set;
        }

        public LogMessageWithFeedback(string text, DateTime timestamp, Action<bool> feedback)
            : base(text, timestamp)
        {
            Feedback = feedback;
        }
    }
}
