using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using CulinarySite.Common.ViewModels.Subscriber;
using CulinarySite.Common.Dtos.Subscriber;
using CulinarySite.Bll.Interfaces;
using System.Linq;

namespace CulinarySite.Api.Controllers
{
    public class SubscriberController : ApiController
    {
        private readonly ISubscriberService _subscriberService;
        private readonly IMapper _mapper;
        public SubscriberController(ISubscriberService subscriberService, IMapper mapper)
        {
            _subscriberService = subscriberService;
            _mapper = mapper;
        }

        [HttpGet("{withRelated}")]
        public IEnumerable<SubscriberListModel> GetSubscriberList(bool withRelated)
        {
            IEnumerable<SubscriberListDto> subscriberListDtos = _subscriberService.GetSubscriberList(withRelated);
            var subscriberListModels = subscriberListDtos.Select(x => _mapper.Map<SubscriberListModel>(x));           

            return subscriberListModels;
        }

        [HttpGet("{id}/{withRelated}")]
        public SubscriberDetailModel GetSubscriber(int id, bool withRelated)
        {
            SubscriberDetailDto subscriberDetailDto = _subscriberService.GetSubscriber(id, withRelated);
            SubscriberDetailModel subscriberDetailModel = _mapper.Map<SubscriberDetailModel>(subscriberDetailDto);

            return subscriberDetailModel;
        }

        [HttpPost]
        public void CreateSubscriber(CreateSubscriberModel createSubscriberModel)
        {
            CreateSubscriberDto createSubscriberDto = _mapper.Map<CreateSubscriberDto>(createSubscriberModel);
            _subscriberService.CreateSubscriber(createSubscriberDto);
        }

        [HttpPut]
        public void UpdateSubscriber(UpdateSubscriberModel updateSubscriberModel)
        {
            UpdateSubscriberDto updateSubscriberDto = _mapper.Map<UpdateSubscriberDto>(updateSubscriberModel);
            _subscriberService.UpdateSubscriber(updateSubscriberDto);
        }

        [HttpDelete("{id}")]
        public void DeleteSubscriber(int id)
        {
            _subscriberService.DeleteSubscriber(id);
        }
    }
}
