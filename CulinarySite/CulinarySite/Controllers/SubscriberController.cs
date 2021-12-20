using System.Collections.Generic;
using ServiceLayer;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace CulinarySite.Controllers
{
    public class SubscriberController : BaseController
    {
        private readonly ISubscriberService subscriberService;
        public SubscriberController(ISubscriberService subscriberService)
        {
            this.subscriberService = subscriberService;
        }

        [HttpGet]
        public IEnumerable<Subscriber> GetSubscriberList()
        {
            return this.subscriberService.GetSubscriberList();
        }

        [HttpGet("{id}")]
        public Subscriber GetSubscriber(int id)
        {
            return this.subscriberService.GetSubscriber(id);
        }

        [HttpPost]
        public void CreateSubscriber(Subscriber subscriber)
        {
            this.subscriberService.CreateSubscriber(subscriber);
        }

        [HttpPut]
        public void UpdateSubscriber(Subscriber subscriber)
        {
            this.subscriberService.UpdateSubscriber(subscriber);
        }

        [HttpDelete("{id}")]
        public void DeleteSubscriber(int id)
        {
            this.subscriberService.DeleteSubscriber(id);
        }
    }
}
