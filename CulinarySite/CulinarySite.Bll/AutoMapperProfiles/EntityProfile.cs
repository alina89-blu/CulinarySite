﻿using AutoMapper;
using CulinarySite.Common.Dtos.Address;
using CulinarySite.Common.Dtos.Author;
using CulinarySite.Common.Dtos.Book;
using CulinarySite.Common.Dtos.Comment;
using CulinarySite.Common.Dtos.CookingStage;
using CulinarySite.Common.Dtos.Dish;
using CulinarySite.Common.Dtos.Ingredient;
using CulinarySite.Common.Dtos.OrganicMatter;
using CulinarySite.Common.Dtos.Recipe;
using CulinarySite.Common.Dtos.Restaurant;
using CulinarySite.Common.Dtos.Telephone;
using CulinarySite.Domain.Entities;

namespace CulinarySite.Bll.AutoMapperProfiles
{

    public class EntityProfile : Profile
    {
        public EntityProfile()
        {
            CreateMap<CreateAddressDto, Address>().ReverseMap();
            CreateMap<UpdateAddressDto, Address>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AddressId)).ReverseMap();

            CreateMap<AddressListDto, Address>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AddressId)).ReverseMap();
            CreateMap<AddressDetailDto, Address>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.AddressId)).ReverseMap();


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

            CreateMap<CreateDishDto, Dish>().ReverseMap();
            CreateMap<UpdateDishDto, Dish>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DishId)).ReverseMap();

            CreateMap<DishDetailDto, Dish>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DishId)).ReverseMap();

            CreateMap<DishListDto, Dish>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DishId)).ReverseMap();

            CreateMap<DishDto, Dish>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DishId)).ReverseMap();

            CreateMap<CreateIngredientDto, Ingredient>().ReverseMap();
            CreateMap<UpdateIngredientDto, Ingredient>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IngredientId)).ReverseMap();

            CreateMap<IngredientDetailDto, Ingredient>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IngredientId)).ReverseMap();

            CreateMap<IngredientListDto, Ingredient>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IngredientId)).ReverseMap();

            CreateMap<IngredientDto, Ingredient>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IngredientId)).ReverseMap();


            CreateMap<CreateOrganicMatterDto, OrganicMatter>().ReverseMap();
            CreateMap<UpdateOrganicMatterDto, OrganicMatter>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrganicMatterId)).ReverseMap();

            CreateMap<OrganicMatterDetailDto, OrganicMatter>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrganicMatterId)).ReverseMap();

            CreateMap<OrganicMatterDto, OrganicMatter>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrganicMatterId)).ReverseMap();

            CreateMap<OrganicMatterListDto, OrganicMatter>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.OrganicMatterId)).ReverseMap();

            CreateMap<CreateRecipeDto, Recipe>().ReverseMap();

            CreateMap<UpdateRecipeDto, Recipe>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RecipeId))
                .ReverseMap();

            CreateMap<RecipeDetailDto, Recipe>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RecipeId))
                .ReverseMap();

            CreateMap<RecipeListDto, Recipe>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RecipeId))
                .ReverseMap();

            CreateMap<RecipeDto, Recipe>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RecipeId)).ReverseMap();

            CreateMap<DishRecipeDto, Recipe>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RecipeId))
                .ReverseMap();

            CreateMap<CreateRestaurantDto, Restaurant>().ReverseMap();
            CreateMap<UpdateRestaurantDto, Restaurant>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RestaurantId)).ReverseMap();

            CreateMap<RestaurantDetailDto, Restaurant>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RestaurantId)).ReverseMap();

            CreateMap<RestaurantDto, Restaurant>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RestaurantId)).ReverseMap();

            CreateMap<RestaurantListDto, Restaurant>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RestaurantId))
                .ForPath(dest => dest.Address.Name, opt => opt.MapFrom(src => src.AddressName))
                .ReverseMap();

            CreateMap<CreateTelephoneDto, Telephone>().ReverseMap();
            CreateMap<UpdateTelephoneDto, Telephone>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TelephoneId)).ReverseMap();

            CreateMap<TelephoneDetailDto, Telephone>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TelephoneId)).ReverseMap();

            CreateMap<TelephoneListDto, Telephone>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TelephoneId))
                .ForPath(dest => dest.Restaurant.Name, opt => opt.MapFrom(src => src.RestaurantName))
                .ReverseMap();

            CreateMap<TelephoneDto, Telephone>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TelephoneId)).ReverseMap();
           
            CreateMap<CreateCommentDto, Comment>().ReverseMap();
            CreateMap<UpdateCommentDto, Comment>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CommentId)).ReverseMap();

            CreateMap<CommentDetailDto, Comment>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CommentId)).ReverseMap();

            CreateMap<CommentListDto, Comment>()                
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CommentId)).ReverseMap();
        }
    }
}
