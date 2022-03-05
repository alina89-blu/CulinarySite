using System.Collections.Generic;
using ServiceLayer.ViewModels.Subscriber;

namespace ServiceLayer
{
    public interface ISubscriberService
    {        
        void CreateSubscriber(CreateSubscriberModel createSubscriberModel);
        void UpdateSubscriber(UpdateSubscriberModel updateSubscriberModel);
        void DeleteSubscriber(int id);
        IEnumerable<SubscriberListModel> GetSubscriberList(bool withRelated);
        SubscriberDetailModel GetSubscriber(int id, bool withRelated);
    }
}
