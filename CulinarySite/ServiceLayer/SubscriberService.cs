using System.Collections.Generic;
using Repositories;
using Database;

namespace ServiceLayer
{
    public class SubscriberService : ISubscriberService
    {
        private readonly IReadOnlyGenericRepository<Subscriber> subscriberReadOnlyRepository;
        private readonly IWriteGenericRepository<Subscriber> subscriberWriteRepository;

        public SubscriberService(
            IReadOnlyGenericRepository<Subscriber> subscriberReadOnlyRepository,
            IWriteGenericRepository<Subscriber> subscriberWriteRepository)
        {
            this.subscriberReadOnlyRepository = subscriberReadOnlyRepository;
            this.subscriberWriteRepository = subscriberWriteRepository;
        }
        public void CreateSubscriber(Subscriber subscriber)
        {
            this.subscriberWriteRepository.Create(subscriber);
            this.subscriberWriteRepository.Save();
        }
        public void UpdateSubscriber(Subscriber subscriber)
        {
            this.subscriberWriteRepository.Update(subscriber);
            this.subscriberWriteRepository.Save();
        }
        public void DeleteSubscriber(int id)
        {
            this.subscriberWriteRepository.Delete(id);
            this.subscriberWriteRepository.Save();
        }
        public IEnumerable<Subscriber> GetSubscriberList()
        {
            return subscriberReadOnlyRepository.GetItemList();
        }
        public Subscriber GetSubscriber(int id)
        {
            return subscriberReadOnlyRepository.GetItem(id);
        }
    }
}
