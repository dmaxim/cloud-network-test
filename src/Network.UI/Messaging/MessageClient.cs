using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rebus.Bus;

namespace Network.UI.Messaging
{
    public class MessageClient : IMessageClient
    {
        private readonly IBus _messageBus;
        public MessageClient(IBus messageBus)
        {
            _messageBus = messageBus;
        }
        
        public async Task Publish<TMessageType>(IList<TMessageType> messages)
        {
            foreach (var message in messages)
            {
                await _messageBus.Publish(message).ConfigureAwait(false);
            }
        }
    }
}