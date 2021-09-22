using System.Collections.Generic;
using System.Threading.Tasks;

namespace Network.UI.Messaging
{
    public interface IQueueClient
    {
        Task Publish<TMessageType>(IList<TMessageType> messages);
    }
}