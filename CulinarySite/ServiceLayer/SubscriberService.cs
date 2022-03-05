using System.Collections.Generic;
using Repositories;
using Database;
using ServiceLayer.ViewModels.Subscriber;

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

        public void CreateSubscriber(CreateSubscriberModel createSubscriberModel)
        {
            var subscriber = new Subscriber
            {
                Name = createSubscriberModel.Name,
                Email = createSubscriberModel.Email
            };
            this.subscriberWriteRepository.Create(subscriber);
            this.subscriberWriteRepository.Save();
        }

        public void UpdateSubscriber(UpdateSubscriberModel updateSubscriberModel)
        {
            var subscriber = new Subscriber
            {
                Id = updateSubscriberModel.SubscriberId,
                Name = updateSubscriberModel.Name,
                Email = updateSubscriberModel.Email
            };
            this.subscriberWriteRepository.Update(subscriber);
            this.subscriberWriteRepository.Save();
        }

        public void DeleteSubscriber(int id)
        {
            this.subscriberWriteRepository.Delete(id);
            this.subscriberWriteRepository.Save();
        }

        public IEnumerable<SubscriberListModel> GetSubscriberList(bool withRelated)
        {
            IEnumerable<Subscriber> subscribers;
            List<SubscriberListModel> subscriberListModels = new List<SubscriberListModel>();
            if (withRelated)
            {
                subscribers = subscriberReadOnlyRepository.GetItemListWithInclude(x => x.Comments);
                foreach (var subscriber in subscribers)
                {
                    subscriberListModels.Add(new SubscriberListModel
                    {
                        SubscriberId = subscriber.Id,
                        Name = subscriber.Name,
                        Email = subscriber.Email
                    });
                }
                return subscriberListModels;
            }
            subscribers = subscriberReadOnlyRepository.GetItemList();
            foreach (var subscriber in subscribers)
            {
                subscriberListModels.Add(new SubscriberListModel
                {
                    SubscriberId = subscriber.Id,
                    Name = subscriber.Name,
                    Email = subscriber.Email
                });
            }
            return subscriberListModels;
        }

        public SubscriberDetailModel GetSubscriber(int id, bool withRelated)
        {
            var subscriber = new Subscriber();
            var subscriberDetailModel = new SubscriberDetailModel();
            if (withRelated)
            {
                subscriber = this.subscriberReadOnlyRepository.GetItemWithInclude(
                    x => x.Id == id,
                    x => x.Comments);
                subscriberDetailModel = new SubscriberDetailModel
                {
                    SubscriberId = subscriber.Id,
                    Name = subscriber.Name,
                    Email = subscriber.Email
                };
                return subscriberDetailModel;
            }
            subscriber = subscriberReadOnlyRepository.GetItem(id);
            subscriberDetailModel = new SubscriberDetailModel
            {
                SubscriberId = subscriber.Id,
                Name = subscriber.Name,
                Email = subscriber.Email
            };
            return subscriberDetailModel;
        }
    }
}
