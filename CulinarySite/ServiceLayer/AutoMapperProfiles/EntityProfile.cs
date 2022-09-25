using AutoMapper;
using Database;
using ServiceLayer.Dtos.Address;
using ServiceLayer.Dtos.Author;
using ServiceLayer.Dtos.Book;
using ServiceLayer.Dtos.CookingStage;
using ServiceLayer.Dtos.CulinaryChannel;
using ServiceLayer.Dtos.Dish;
using ServiceLayer.Dtos.Episode;
using ServiceLayer.Dtos.Ingredient;
using ServiceLayer.Dtos.OrganicMatter;
using ServiceLayer.Dtos.Recipe;
using ServiceLayer.Dtos.Restaurant;
using ServiceLayer.Dtos.Tag;
using ServiceLayer.Dtos.Telephone;

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



            CreateMap<CreateDishDto, Dish>().ReverseMap();
            CreateMap<UpdateDishDto, Dish>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DishId)).ReverseMap();

            CreateMap<DishDetailDto, Dish>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DishId)).ReverseMap();

            CreateMap<DishListDto, Dish>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.DishId)).ReverseMap();


            CreateMap<CreateEpisodeDto, Episode>().ReverseMap();
            CreateMap<UpdateEpisodeDto, Episode>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EpisodeId)).ReverseMap();

            CreateMap<EpisodeDetailDto, Episode>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EpisodeId)).ReverseMap();

            CreateMap<EpisodeListDto, Episode>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EpisodeId))
                .ForPath(dest => dest.CulinaryChannel.Name, opt => opt.MapFrom(src => src.CulinaryChannelName))
                .ReverseMap();



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


            CreateMap<CreateTagDto, Tag>().ReverseMap();
            CreateMap<UpdateTagDto, Tag>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TagId)).ReverseMap();

            CreateMap<TagDetailDto, Tag>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TagId)).ReverseMap();

            CreateMap<TagListDto, Tag>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TagId)).ReverseMap();

            CreateMap<TagDto, Tag>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.TagId)).ReverseMap();


            CreateMap<CreateRecipeDto, Recipe>().ReverseMap();
            CreateMap<UpdateRecipeDto, Recipe>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RecipeId)).ReverseMap();

            CreateMap<RecipeDetailDto, Recipe>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RecipeId)).ReverseMap();

            CreateMap<RecipeListDto, Recipe>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RecipeId)).ReverseMap();

            CreateMap<RecipeDto, Recipe>().ReverseMap();


            CreateMap<CreateRestaurantDto, Restaurant>().ReverseMap();
            CreateMap<UpdateRestaurantDto, Restaurant>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.RestaurantId)).ReverseMap();

            CreateMap<RestaurantDetailDto, Restaurant>()
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


        }
    }
}
