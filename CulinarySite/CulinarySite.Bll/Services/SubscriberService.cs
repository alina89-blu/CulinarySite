using System.Collections.Generic;
using AutoMapper;
using CulinarySite.Bll.Interfaces;
using CulinarySite.Common.Dtos.Subscriber;
using CulinarySite.Dal.Interfaces;
using CulinarySite.Domain.Entities;
using System.Linq;

namespace CulinarySite.Bll.Services
{
    public class SubscriberService : ISubscriberService
    {
        private readonly IReadOnlyGenericRepository<Subscriber> _subscriberReadOnlyRepository;
        private readonly IWriteGenericRepository<Subscriber> _subscriberWriteRepository;
        private readonly IMapper _mapper;
        public SubscriberService(
            IReadOnlyGenericRepository<Subscriber> subscriberReadOnlyRepository,
            IWriteGenericRepository<Subscriber> subscriberWriteRepository,
            IMapper mapper)
        {
            _subscriberReadOnlyRepository = subscriberReadOnlyRepository;
            _subscriberWriteRepository = subscriberWriteRepository;
            _mapper = mapper;
        }

        public void CreateSubscriber(CreateSubscriberDto createSubscriberDto)
        {
            Subscriber subscriber = _mapper.Map<Subscriber>(createSubscriberDto);

            _subscriberWriteRepository.Create(subscriber);
            _subscriberWriteRepository.Save();
        }

        public void UpdateSubscriber(UpdateSubscriberDto updateSubscriberDto)
        {
            Subscriber subscriber = _mapper.Map<Subscriber>(updateSubscriberDto);

            _subscriberWriteRepository.Update(subscriber);
            _subscriberWriteRepository.Save();
        }

        public void DeleteSubscriber(int id)
        {
            _subscriberWriteRepository.Delete(id);
            _subscriberWriteRepository.Save();
        }

        public IEnumerable<SubscriberListDto> GetSubscriberList(bool withRelated)
        {
            IEnumerable<Subscriber> subscribers;
            IEnumerable<SubscriberListDto> subscriberListDtos ;

            if (withRelated)
            {
                subscribers = _subscriberReadOnlyRepository.GetItemListWithInclude(x => x.Comments);
                subscriberListDtos = subscribers.Select(x => _mapper.Map<SubscriberListDto>(x));
               
                return subscriberListDtos;
            }

            subscribers = _subscriberReadOnlyRepository.GetItemList();
            subscriberListDtos = subscribers.Select(x => _mapper.Map<SubscriberListDto>(x));

            return subscriberListDtos;
        }

        public SubscriberDetailDto GetSubscriber(int id, bool withRelated)
        {
            var subscriber = new Subscriber();
            var subscriberDetailDto = new SubscriberDetailDto();

            if (withRelated)
            {
                subscriber = _subscriberReadOnlyRepository.GetItemWithInclude(
                    x => x.Id == id,
                    x => x.Comments);

                subscriberDetailDto = _mapper.Map<SubscriberDetailDto>(subscriber);

                return subscriberDetailDto;
            }

            subscriber = _subscriberReadOnlyRepository.GetItem(id);

            subscriberDetailDto = _mapper.Map<SubscriberDetailDto>(subscriber);

            return subscriberDetailDto;
        }

    }
}
