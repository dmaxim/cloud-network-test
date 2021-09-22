using System;

namespace Network.UI.Messaging
{
    public class DemoEvent
    {
        public DemoEvent() {}

        public DemoEvent(DateTime receivedDate, string description, string status)
        {
            ReceivedDate = receivedDate;
            Description = description;
            Status = status;
        }
        
        public DateTime ReceivedDate { get; set; }
        public string Description { get; set;  }
        public string Status { get; set;  }
    }
}