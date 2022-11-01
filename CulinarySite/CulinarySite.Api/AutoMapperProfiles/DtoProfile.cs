using AutoMapper;
using CulinarySite.Common.Dtos.Address;
using CulinarySite.Common.Dtos.Author;
using CulinarySite.Common.Dtos.Book;
using CulinarySite.Common.Dtos.Comment;
using CulinarySite.Common.Dtos.CookingStage;
using CulinarySite.Common.Dtos.CulinaryChannel;
using CulinarySite.Common.Dtos.Dish;
using CulinarySite.Common.Dtos.Episode;
using CulinarySite.Common.Dtos.Ingredient;
using CulinarySite.Common.Dtos.OrganicMatter;
using CulinarySite.Common.Dtos.Recipe;
using CulinarySite.Common.Dtos.Restaurant;
using CulinarySite.Common.Dtos.Subscriber;
using CulinarySite.Common.Dtos.Tag;
using CulinarySite.Common.Dtos.Telephone;
using CulinarySite.Common.Pagination;
using CulinarySite.Common.ViewModels.Address;
using CulinarySite.Common.ViewModels.Author;
using CulinarySite.Common.ViewModels.Book;
using CulinarySite.Common.ViewModels.Comment;
using CulinarySite.Common.ViewModels.CookingStage;
using CulinarySite.Common.ViewModels.CulinaryChannel;
using CulinarySite.Common.ViewModels.Dish;
using CulinarySite.Common.ViewModels.Episode;
using CulinarySite.Common.ViewModels.Ingredient;
using CulinarySite.Common.ViewModels.OrganicMatter;
using CulinarySite.Common.ViewModels.Recipe;
using CulinarySite.Common.ViewModels.Restaurant;
using CulinarySite.Common.ViewModels.Subscriber;
using CulinarySite.Common.ViewModels.Tag;
using CulinarySite.Common.ViewModels.Telephone;
using CulinarySite.Domain.Entities;
using System.Threading.Tasks;

namespace CulinarySite.Api.AutoMapperProfiles
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
            CreateMap<DishModel, DishDto>().ReverseMap();


            CreateMap<CreateEpisodeModel, CreateEpisodeDto>().ReverseMap();
            CreateMap<UpdateEpisodeModel, UpdateEpisodeDto>().ReverseMap();
            CreateMap<EpisodeDetailModel, EpisodeDetailDto>().ReverseMap();
            CreateMap<EpisodeListModel, EpisodeListDto>().ReverseMap();

            CreateMap<CreateIngredientModel, CreateIngredientDto>().ReverseMap();
            CreateMap<UpdateIngredientModel, UpdateIngredientDto>().ReverseMap();
            CreateMap<IngredientDetailModel, IngredientDetailDto>().ReverseMap();
            CreateMap<IngredientListModel, IngredientListDto>().ReverseMap();
            CreateMap<IngredientModel, IngredientDto>().ReverseMap();

            CreateMap<CreateOrganicMatterModel, CreateOrganicMatterDto>().ReverseMap();
            CreateMap<UpdateOrganicMatterModel, UpdateOrganicMatterDto>().ReverseMap();
            CreateMap<OrganicMatterDetailModel, OrganicMatterDetailDto>().ReverseMap();
            CreateMap<OrganicMatterModel, OrganicMatterDto>().ReverseMap();
            CreateMap<OrganicMatterListModel, OrganicMatterListDto>().ReverseMap();

            CreateMap<CreateTagModel, CreateTagDto>().ReverseMap();
            CreateMap<UpdateTagModel, UpdateTagDto>().ReverseMap();
            CreateMap<TagDetailModel, TagDetailDto>().ReverseMap();
            CreateMap<TagListModel, TagListDto>().ReverseMap();
            CreateMap<TagModel, TagDto>().ReverseMap();

            CreateMap<CreateRecipeModel, CreateRecipeDto>().ReverseMap();
            CreateMap<UpdateRecipeModel, UpdateRecipeDto>().ReverseMap();
            CreateMap<RecipeDetailModel, RecipeDetailDto>().ReverseMap();
            CreateMap<RecipeListModel, RecipeListDto>().ReverseMap();
            CreateMap<RecipeModel, RecipeDto>().ReverseMap();

            CreateMap<CreateRestaurantModel, CreateRestaurantDto>().ReverseMap();
            CreateMap<UpdateRestaurantModel, UpdateRestaurantDto>().ReverseMap();
            CreateMap<RestaurantDetailModel, RestaurantDetailDto>().ReverseMap();
            CreateMap<RestaurantListModel, RestaurantListDto>().ReverseMap();
            CreateMap<RestaurantModel, RestaurantDto>().ReverseMap();

            CreateMap<CreateTelephoneModel, CreateTelephoneDto>().ReverseMap();
            CreateMap<UpdateTelephoneModel, UpdateTelephoneDto>().ReverseMap();
            CreateMap<TelephoneDetailModel, TelephoneDetailDto>().ReverseMap();
            CreateMap<TelephoneListModel, TelephoneListDto>().ReverseMap();
            CreateMap<TelephoneModel, TelephoneDto>().ReverseMap();

            CreateMap<CreateSubscriberModel, CreateSubscriberDto>().ReverseMap();
            CreateMap<UpdateSubscriberModel, UpdateSubscriberDto>().ReverseMap();
            CreateMap<SubscriberListModel, SubscriberListDto>().ReverseMap();
            CreateMap<SubscriberDetailModel, SubscriberDetailDto>().ReverseMap();

            CreateMap<CreateCommentModel, CreateCommentDto>().ReverseMap();
            CreateMap<UpdateCommentModel, UpdateCommentDto>().ReverseMap();
            CreateMap<CommentListModel, CommentListDto>().ReverseMap();
            CreateMap<CommentDetailModel, CommentDetailDto>().ReverseMap();

        
            

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
