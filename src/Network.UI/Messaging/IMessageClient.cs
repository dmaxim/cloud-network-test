using System.Collections.Generic;
using System.Threading.Tasks;

namespace Network.UI.Messaging
{
    public interface IMessageClient
    {
        Task Publish<TMessageType>(IList<TMessageType> messages);
    }
}