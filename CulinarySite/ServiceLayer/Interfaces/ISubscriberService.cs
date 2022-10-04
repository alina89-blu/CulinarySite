using ServiceLayer.Dtos.Subscriber;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface ISubscriberService
    {
        void CreateSubscriber(CreateSubscriberDto createSubscriberDto);
        void UpdateSubscriber(UpdateSubscriberDto updateSubscriberDto);
        void DeleteSubscriber(int id);
        IEnumerable<SubscriberListDto> GetSubscriberList(bool withRelated);
        SubscriberDetailDto GetSubscriber(int id, bool withRelated);
    }
}
