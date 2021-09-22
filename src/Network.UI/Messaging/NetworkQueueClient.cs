using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Storage.Queues;
using Newtonsoft.Json;

namespace Network.UI.Messaging
{
    public class NetworkQueueClient : IQueueClient
    {
        private readonly QueueClient _queueClient;
        public NetworkQueueClient(string connectionString)
        {
            _queueClient = new QueueClient(connectionString, "demoevent");
        }

        public async Task Publish<TMessageType>(IList<TMessageType> messages)
        {
            await _queueClient.CreateIfNotExistsAsync().ConfigureAwait(false);

            foreach (var message in messages)
            {
                var messageJson = JsonConvert.SerializeObject(message);
                await _queueClient.SendMessageAsync(messageJson).ConfigureAwait(false);
            }
        }
        
    }

}