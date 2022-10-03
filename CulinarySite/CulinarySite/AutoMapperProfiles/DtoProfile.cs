using AutoMapper;
using ServiceLayer.Dtos.Address;
using ServiceLayer.Dtos.Author;
using ServiceLayer.Dtos.Book;
using ServiceLayer.Dtos.Comment;
using ServiceLayer.Dtos.CookingStage;
using ServiceLayer.Dtos.CulinaryChannel;
using ServiceLayer.Dtos.Dish;
using ServiceLayer.Dtos.Episode;
using ServiceLayer.Dtos.Image.DishImage;
using ServiceLayer.Dtos.Image.EpisodeImage;
using ServiceLayer.Dtos.Image.RecipeImage;
using ServiceLayer.Dtos.Ingredient;
using ServiceLayer.Dtos.OrganicMatter;
using ServiceLayer.Dtos.Recipe;
using ServiceLayer.Dtos.Restaurant;
using ServiceLayer.Dtos.Subscriber;
using ServiceLayer.Dtos.Tag;
using ServiceLayer.Dtos.Telephone;
using ServiceLayer.ViewModels.Address;
using ServiceLayer.ViewModels.Author;
using ServiceLayer.ViewModels.Book;
using ServiceLayer.ViewModels.Comment;
using ServiceLayer.ViewModels.CookingStage;
using ServiceLayer.ViewModels.CulinaryChannel;
using ServiceLayer.ViewModels.Dish;
using ServiceLayer.ViewModels.Episode;
using ServiceLayer.ViewModels.Image.DishImage;
using ServiceLayer.ViewModels.Image.EpisodeImage;
using ServiceLayer.ViewModels.Image.RecipeImage;
using ServiceLayer.ViewModels.Ingredient;
using ServiceLayer.ViewModels.OrganicMatter;
using ServiceLayer.ViewModels.Recipe;
using ServiceLayer.ViewModels.Restaurant;
using ServiceLayer.ViewModels.Subscriber;
using ServiceLayer.ViewModels.Tag;
using ServiceLayer.ViewModels.Telephone;

namespace CulinaryApi.AutoMapperProfiles
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

            CreateMap<CreateDishImageModel, CreateDishImageDto>().ReverseMap();
            CreateMap<UpdateDishImageModel, UpdateDishImageDto>().ReverseMap();
            CreateMap<DishImageListModel, DishImageListDto>().ReverseMap();
            CreateMap<DishImageDetailModel, DishImageDetailDto>().ReverseMap();
            CreateMap<DishImageModel, DishImageDto>().ReverseMap();

            CreateMap<CreateEpisodeImageModel, CreateEpisodeImageDto>().ReverseMap();
            CreateMap<UpdateEpisodeImageModel, UpdateEpisodeImageDto>().ReverseMap();
            CreateMap<EpisodeImageListModel, EpisodeImageListDto>().ReverseMap();
            CreateMap<EpisodeImageDetailModel, EpisodeImageDetailDto>().ReverseMap();

            CreateMap<CreateRecipeImageModel, CreateRecipeImageDto>().ReverseMap();
            CreateMap<UpdateRecipeImageModel, UpdateRecipeImageDto>().ReverseMap();
            CreateMap<RecipeImageListModel, RecipeImageListDto>().ReverseMap();
            CreateMap<RecipeImageDetailModel, RecipeImageDetailDto>().ReverseMap();
            CreateMap<RecipeImageModel, RecipeImageDto>().ReverseMap();


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
