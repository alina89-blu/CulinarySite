using System.Collections.Generic;
using AutoMapper;
using Database.Entities;
using Repositories;
using ServiceLayer.Dtos.CulinaryChannel;

namespace ServiceLayer
{
    public class CulinaryChannelService : ICulinaryChannelService
    {
        private readonly IReadOnlyGenericRepository<CulinaryChannel> _culinaryChannelReadOnlyRepository;
        private readonly IWriteGenericRepository<CulinaryChannel> _culinaryChannelWriteRepository;
        private readonly IMapper _mapper;
        public CulinaryChannelService(
            IReadOnlyGenericRepository<CulinaryChannel> culinaryChannelReadOnlyRepository,
            IWriteGenericRepository<CulinaryChannel> culinaryChannelWriteRepository,
            IMapper mapper)
        {
            _culinaryChannelReadOnlyRepository = culinaryChannelReadOnlyRepository;
            _culinaryChannelWriteRepository = culinaryChannelWriteRepository;
            _mapper = mapper;
        }

        public void CreateCulinaryChannel(CreateCulinaryChannelDto createCulinaryChannelDto)
        {
            CulinaryChannel culinaryChannel = _mapper.Map<CulinaryChannel>(createCulinaryChannelDto);
            _culinaryChannelWriteRepository.Create(culinaryChannel);
            _culinaryChannelWriteRepository.Save();
        }

        public void UpdateCulinaryChannel(UpdateCulinaryChannelDto updateCulinaryChannelDto)
        {
            CulinaryChannel culinaryChannel = _mapper.Map<CulinaryChannel>(updateCulinaryChannelDto);
            _culinaryChannelWriteRepository.Update(culinaryChannel);
            _culinaryChannelWriteRepository.Save();
        }

        public void DeleteCulinaryChannel(int id)
        {
            _culinaryChannelWriteRepository.Delete(id);
            _culinaryChannelWriteRepository.Save();
        }

        public IEnumerable<CulinaryChannelListDto> GetCulinaryChannelList(bool withRelated)
        {
            IEnumerable<CulinaryChannel> culinaryChannels;
            var culinaryChannelListDtos = new List<CulinaryChannelListDto>();

            if (withRelated)
            {
                culinaryChannels = _culinaryChannelReadOnlyRepository.GetItemListWithInclude(x => x.Episodes);
                foreach (var culinaryChannel in culinaryChannels)
                {
                    culinaryChannelListDtos.Add(_mapper.Map<CulinaryChannelListDto>(culinaryChannel));
                }

                return culinaryChannelListDtos;
            }
            culinaryChannels = _culinaryChannelReadOnlyRepository.GetItemList();

            foreach (var culinaryChannel in culinaryChannels)
            {
                culinaryChannelListDtos.Add(_mapper.Map<CulinaryChannelListDto>(culinaryChannel));
            }

            return culinaryChannelListDtos;
        }

        public CulinaryChannelDetailDto GetCulinaryChannel(int id, bool withRelated)
        {
            var culinaryChannel = new CulinaryChannel();
            var culinaryChannelDetailDto = new CulinaryChannelDetailDto();

            if (withRelated)
            {
                culinaryChannel = _culinaryChannelReadOnlyRepository.GetItemWithInclude(
                x => x.Id == id,
                x => x.Episodes);

                culinaryChannelDetailDto = _mapper.Map<CulinaryChannelDetailDto>(culinaryChannel);

                return culinaryChannelDetailDto;
            }

            culinaryChannel = _culinaryChannelReadOnlyRepository.GetItem(id);

            culinaryChannelDetailDto = _mapper.Map<CulinaryChannelDetailDto>(culinaryChannel);

            return culinaryChannelDetailDto;
        }
    }
}
