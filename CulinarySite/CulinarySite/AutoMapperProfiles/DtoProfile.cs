﻿using AutoMapper;
using ServiceLayer.Dtos.Address;
using ServiceLayer.Dtos.Author;
using ServiceLayer.Dtos.Book;
using ServiceLayer.Dtos.CookingStage;
using ServiceLayer.Dtos.CulinaryChannel;
using ServiceLayer.Dtos.Dish;
using ServiceLayer.Dtos.Episode;
using ServiceLayer.ViewModels.Address;
using ServiceLayer.ViewModels.Author;
using ServiceLayer.ViewModels.Book;
using ServiceLayer.ViewModels.CookingStage;
using ServiceLayer.ViewModels.CulinaryChannel;
using ServiceLayer.ViewModels.Dish;
using ServiceLayer.ViewModels.Episode;

namespace CulinarySite.AutoMapperProfiles
{
    public class DtoProfile : Profile
    {
        public DtoProfile()
        {
            CreateMap<CreateAddressModel, CreateAddressDto>().ReverseMap();
            CreateMap<UpdateAddressModel, UpdateAddressDto>().ReverseMap();
            CreateMap<AddressListModel, AddressListDto>().ReverseMap();
            CreateMap<AddressDetailModel, AddressDetailDto>().ReverseMap();

            CreateMap<CreateAuthorModel, CreateAuthorDto>().ReverseMap();
            CreateMap<UpdateAuthorModel, UpdateAuthorDto>().ReverseMap();
            CreateMap<AuthorListModel, AuthorListDto>().ReverseMap();
            CreateMap<AuthorDetailModel, AuthorDetailDto>().ReverseMap();

            CreateMap<CreateBookModel, CreateBookDto>().ReverseMap();
            CreateMap<UpdateBookModel, UpdateBookDto>().ReverseMap();
            CreateMap<BookDetailModel, BookDetailDto>().ReverseMap();
            CreateMap<BookModel, BookDto>().ReverseMap();
            CreateMap<BookDetailListModel, BookDetailListDto>().ReverseMap();

            CreateMap<CreateCookingStageModel, CreateCookingStageDto>().ReverseMap();
            CreateMap<UpdateCookingStageModel, UpdateCookingStageDto>().ReverseMap();
            CreateMap<CookingStageListModel, CookingStageListDto>().ReverseMap();
            CreateMap<CookingStageModel, CookingStageDto>().ReverseMap();
            CreateMap<CookingStageDetailModel, CookingStageDetailDto>().ReverseMap();

            CreateMap<CreateCulinaryChannelModel, CreateCulinaryChannelDto>().ReverseMap();
            CreateMap<UpdateCulinaryChannelModel, UpdateCulinaryChannelDto>().ReverseMap();
            CreateMap<CulinaryChannelDetailModel, CulinaryChannelDetailDto>().ReverseMap();
            CreateMap<CulinaryChannelListModel, CulinaryChannelListDto>().ReverseMap();

            CreateMap<CreateDishModel, CreateDishDto>().ReverseMap();
            CreateMap<UpdateDishModel, UpdateDishDto>().ReverseMap();
            CreateMap<DishDetailModel, DishDetailDto>().ReverseMap();
            CreateMap<DishListModel, DishListDto>().ReverseMap();

            CreateMap<CreateEpisodeModel, CreateEpisodeDto>().ReverseMap();
            CreateMap<UpdateEpisodeModel, CreateEpisodeDto>().ReverseMap();
            CreateMap<EpisodeDetailModel, EpisodeDetailDto>().ReverseMap();
            CreateMap<EpisodeListModel, EpisodeListDto>().ReverseMap();



            // CreateMap<List<AddressListModel>, List<AddressListDto>>().ReverseMap();

            //.ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name + " test "));


            /*  CreateMap<User, UserViewModel>()
          .ForMember(dest =>
              dest.FName,
              opt => opt.MapFrom(src => src.FirstName))
          .ForMember(dest =>
              dest.LName,
              opt => opt.MapFrom(src => src.LastName))
          .ReverseMap();*/
        }
    }
}