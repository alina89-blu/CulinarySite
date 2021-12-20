using Database;
using System.Collections.Generic;

namespace ServiceLayer
{
    public interface ISubscriberService
    {
        void CreateSubscriber(Subscriber subscriber);
        void UpdateSubscriber(Subscriber subscriber);
        void DeleteSubscriber(int id);
        IEnumerable<Subscriber> GetSubscriberList();
        Subscriber GetSubscriber(int id);
    }
}
