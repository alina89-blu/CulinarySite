using AutoMapper;
using Database;
using ServiceLayer.Dtos.Address;
using ServiceLayer.Dtos.Author;
using ServiceLayer.Dtos.Book;
using ServiceLayer.Dtos.CookingStage;
using ServiceLayer.Dtos.CulinaryChannel;
using ServiceLayer.Dtos.Dish;
using ServiceLayer.Dtos.Episode;

namespace ServiceLayer.AutoMapperProfiles
{

    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<CreateAddressDto, Address>().ReverseMap();
            CreateMap<UpdateAddressDto, Address>().ReverseMap();
            CreateMap<AddressListDto, Address>().ReverseMap();
            CreateMap<AddressDetailDto, Address>().ReverseMap();

            CreateMap<CreateAuthorDto, Author>().ReverseMap();
            CreateMap<UpdateAuthorDto, Author>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AuthorId)).ReverseMap();

            CreateMap<AuthorListDto, Author>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AuthorId)).ReverseMap();

            CreateMap<AuthorDetailDto, Author>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AuthorId)).ReverseMap();

            CreateMap<CreateBookDto, Book>().ReverseMap();
            CreateMap<UpdateBookDto, Book>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BookId)).ReverseMap();

            CreateMap<BookDetailDto, Book>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BookId)).ReverseMap();

            CreateMap<BookDto, Book>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BookId)).ReverseMap();

            CreateMap<BookDetailListDto, Book>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BookId))
                .ForPath(dest => dest.Author.Name, opt => opt.MapFrom(src => src.AuthorName))
                .ReverseMap();



            CreateMap<CreateCookingStageDto, CookingStage>().ReverseMap();
            CreateMap<UpdateCookingStageDto, CookingStage>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CookingStageId)).ReverseMap();

            CreateMap<CookingStageListDto, CookingStage>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CookingStageId))
                .ForPath(dest => dest.Recipe.Name, opt => opt.MapFrom(src => src.RecipeName))
                .ReverseMap();

            CreateMap<CookingStageDto, CookingStage>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CookingStageId)).ReverseMap();

            CreateMap<CookingStageDetailDto, CookingStage>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CookingStageId)).ReverseMap();

            
            CreateMap<CreateCulinaryChannelDto, CulinaryChannel>().ReverseMap();
            CreateMap<UpdateCulinaryChannelDto, CulinaryChannel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CulinaryChannelId)).ReverseMap();

            CreateMap<CulinaryChannelDetailDto, CulinaryChannel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CulinaryChannelId)).ReverseMap();

            CreateMap<CulinaryChannelListDto, CulinaryChannel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CulinaryChannelId)).ReverseMap();

            ///

            CreateMap<CreateDishDto, Dish>().ReverseMap();
            CreateMap<UpdateDishDto, Dish>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DishId)).ReverseMap();

            CreateMap<DishDetailDto, Dish>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DishId)).ReverseMap();

            CreateMap<DishListDto, Dish>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DishId)).ReverseMap();

////////
            CreateMap<CreateEpisodeDto, Episode>().ReverseMap();
            CreateMap<UpdateEpisodeDto, Episode>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EpisodeId)).ReverseMap();

            CreateMap<EpisodeDetailDto, Episode>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EpisodeId)).ReverseMap();

            CreateMap<EpisodeListDto, Episode>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EpisodeId))
                .ForPath(dest => dest.CulinaryChannel.Name, opt => opt.MapFrom(src => src.CulinaryChannelName))
                .ReverseMap();


        }
    }
}
