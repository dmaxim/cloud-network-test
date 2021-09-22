using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Network.UI.Messaging;

namespace Network.UI.Controllers
{
    public class Publisher : Controller
    {
        private readonly IMessageClient _messageClient;
        private readonly IQueueClient _queueClient;
        public Publisher(IMessageClient messageClient, IQueueClient queueClient)
        {
            _messageClient = messageClient;
            _queueClient = queueClient;
        }
        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Publish()
        {
            var eventList = new List<DemoEvent>()
            {
                new DemoEvent(DateTime.Now.AddDays(-3), "EventOne", "New"),
                new DemoEvent(DateTime.Now.AddDays(-2), "EventTwo", "New"),
                new DemoEvent(DateTime.Now, "EventThree", "New"),
            };
            //await _messageClient.Publish(eventList).ConfigureAwait(false);
            await _queueClient.Publish(eventList).ConfigureAwait(false);
            return RedirectToAction("Index");
        }
        
    }
}