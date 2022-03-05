using System.Collections.Generic;
using ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ViewModels.Subscriber;

namespace CulinarySite.Controllers
{
    public class SubscriberController : BaseController
    {
        private readonly ISubscriberService subscriberService;
        public SubscriberController(ISubscriberService subscriberService)
        {
            this.subscriberService = subscriberService;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<SubscriberListModel> GetSubscriberList(bool withRelated)
        {
            return this.subscriberService.GetSubscriberList(withRelated);
        }

        [HttpGet("{id}/{withRelated}")]
        public SubscriberDetailModel GetSubscriber(int id, bool withRelated)
        {
            return this.subscriberService.GetSubscriber(id, withRelated);
        }

        [HttpPost]
        public void CreateSubscriber(CreateSubscriberModel createSubscriberModel)
        {
            this.subscriberService.CreateSubscriber(createSubscriberModel);
        }

        [HttpPut]
        public void UpdateSubscriber(UpdateSubscriberModel updateSubscriberModel)
        {
            this.subscriberService.UpdateSubscriber(updateSubscriberModel);
        }

        [HttpDelete("{id}")]
        public void DeleteSubscriber(int id)
        {
            this.subscriberService.DeleteSubscriber(id);
        }
    }
}
