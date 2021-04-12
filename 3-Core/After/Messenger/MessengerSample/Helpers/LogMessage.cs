using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerSample.Helpers
{
    public class LogMessage
    {
        public LogMessage(string text, DateTime timestamp)
        {
            Timestamp = timestamp;
            Text = text;
        }

        public string Text
        {
            get;
            private set;
        }

        public DateTime Timestamp
        {
            get;
            private set;
        }
    }
}
