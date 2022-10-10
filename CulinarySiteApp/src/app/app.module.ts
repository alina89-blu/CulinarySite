import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';

import { AddressService } from './services/address.service';
import { AuthorService } from './services/author.service';
import { BookService } from './services/book.service';
import { CommentService } from './services/comment.service';
import { CookingStageService } from './services/cooking-stage.service';
import { CulinaryChannelService } from './services/culinary-channel.service';
import { DishService } from './services/dish.service';
import { EpisodeService } from './services/episode.service';
import { ImageService } from './services/image.service';
import { IngredientService } from './services/ingredient.service';
import { OrganicMatterService } from './services/organic-matter.service';
import { RecipeService } from './services/recipe.service';
import { RestaurantService } from './services/restaurant.service';
import { SubscriberService } from './services/subscriber.service';
import { TagService } from './services/tag.service';
import { TelephoneService } from './services/telephone.service';
import { RecipeOrganicMatterService } from './services/recipe-organic-matter.service';
import { AuthService } from './services/auth.service';

import { AppComponent } from './app.component';
import { AddressListComponent } from './address/address-list/address-list.component';
import { AddressEditComponent } from './address/address-edit/address-edit.component';
import { AddressCreateComponent } from './address/address-create/address-create.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AuthorListComponent } from './author/author-list/author-list.component';
import { AuthorCreateComponent } from './author/author-create/author-create.component';
import { AuthorEditComponent } from './author/author-edit/author-edit.component';
import { BookListComponent } from './book/book-list/book-list.component';
import { BookEditComponent } from './book/book-edit/book-edit.component';
import { BookCreateComponent } from './book/book-create/book-create.component';
import { CookingStageListComponent } from './cooking-stage/cooking-stage-list/cooking-stage-list.component';
import { CookingStageCreateComponent } from './cooking-stage/cooking-stage-create/cooking-stage-create.component';
import { CookingStageEditComponent } from './cooking-stage/cooking-stage-edit/cooking-stage-edit.component';
import { CulinaryChannelListComponent } from './culinary-channel/culinary-channel-list/culinary-channel-list.component';
import { CulinaryChannelCreateComponent } from './culinary-channel/culinary-channel-create/culinary-channel-create.component';
import { CulinaryChannelEditComponent } from './culinary-channel/culinary-channel-edit/culinary-channel-edit.component';
import { DishListComponent } from './dish/dish-list/dish-list.component';
import { DishCreateComponent } from './dish/dish-create/dish-create.component';
import { DishEditComponent } from './dish/dish-edit/dish-edit.component';
import { RecipeListComponent } from './recipe/recipe-list/recipe-list.component';
import { RecipeCreateComponent } from './recipe/recipe-create/recipe-create.component';
import { RecipeEditComponent } from './recipe/recipe-edit/recipe-edit.component';
import { RecipeDetailComponent } from './recipe/recipe-detail/recipe-detail.component';
import { EpisodeListComponent } from './episode/episode-list/episode-list.component';
import { EpisodeCreateComponent } from './episode/episode-create/episode-create.component';
import { EpisodeEditComponent } from './episode/episode-edit/episode-edit.component';
import { CernovicComponent } from './cernovic/cernovic.component';
import { RecipeLibraryComponent } from './recipe-library/recipe-library.component';
import { BookLibraryComponent } from './book-library/book-library.component';
import { RestaurantLibraryComponent } from './restaurant-library/restaurant-library.component';
import { BookDetailComponent } from './book/book-detail/book-detail.component';
import { DishDetailComponent } from './dish/dish-detail/dish-detail.component';
import { TelephoneCreateComponent } from './telephone/telephone-create/telephone-create.component';
import { TelephoneEditComponent } from './telephone/telephone-edit/telephone-edit.component';
import { TelephoneListComponent } from './telephone/telephone-list/telephone-list.component';
import { RestaurantCreateComponent } from './restaurant/restaurant-create/restaurant-create.component';
import { RestaurantEditComponent } from './restaurant/restaurant-update/restaurant-edit.component';
import { RestaurantListComponent } from './restaurant/restaurant-list/restaurant-list.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuardService } from './services/auth-guard.service';

const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'address', component: AddressListComponent },
  { path: 'editAddress/:id', component: AddressEditComponent },
  { path: 'createAddress', component: AddressCreateComponent },
  { path: 'author', component: AuthorListComponent },
  { path: 'createAuthor', component: AuthorCreateComponent },
  { path: 'editAuthor/:id', component: AuthorEditComponent },
  { path: 'book', component: BookListComponent },
  { path: 'editBook/:id', component: BookEditComponent },

  /* {
    path: 'createBook',
    component: BookCreateComponent,
    canActivate: [AuthGuardService],
  },*/

  { path: 'createBook', component: BookCreateComponent },
  { path: 'cookingStage', component: CookingStageListComponent },
  { path: 'createCookingStage', component: CookingStageCreateComponent },
  { path: 'editCookingStage/:id', component: CookingStageEditComponent },
  { path: 'culinaryChannel', component: CulinaryChannelListComponent },
  { path: 'createCulinaryChannel', component: CulinaryChannelCreateComponent },
  { path: 'editCulinaryChannel/:id', component: CulinaryChannelEditComponent },
  { path: 'dish', component: DishListComponent },
  { path: 'createDish', component: DishCreateComponent },
  { path: 'editDish/:id', component: DishEditComponent },
  { path: 'recipe', component: RecipeListComponent },
  { path: 'createRecipe', component: RecipeCreateComponent },
  { path: 'editRecipe/:id', component: RecipeEditComponent },
  { path: 'recipe/:id', component: RecipeDetailComponent },
  { path: 'episode', component: EpisodeListComponent },
  { path: 'createEpisode', component: EpisodeCreateComponent },
  { path: 'editEpisode/:id', component: EpisodeEditComponent },
  { path: 'recipeLibrary', component: RecipeLibraryComponent },
  { path: 'bookLibrary', component: BookLibraryComponent },
  { path: 'restaurantLibrary', component: RestaurantLibraryComponent },
  { path: 'book/:id', component: BookDetailComponent },
  { path: 'dish/:id', component: DishDetailComponent },
  { path: 'telephone', component: TelephoneListComponent },
  { path: 'editTelephone/:id', component: TelephoneEditComponent },
  { path: 'createTelephone', component: TelephoneCreateComponent },
  { path: 'restaurant', component: RestaurantListComponent },
  { path: 'editRestaurant/:id', component: RestaurantEditComponent },
  { path: 'createRestaurant', component: RestaurantCreateComponent },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
  { path: 'cernovic', component: CernovicComponent },

  //
];

@NgModule({
  declarations: [
    AppComponent,
    AddressListComponent,
    AddressEditComponent,
    AddressCreateComponent,
    NavMenuComponent,
    HomeComponent,
    AuthorListComponent,
    AuthorCreateComponent,
    AuthorEditComponent,
    BookListComponent,
    BookEditComponent,
    BookCreateComponent,
    CookingStageListComponent,
    CookingStageCreateComponent,
    CookingStageEditComponent,
    CulinaryChannelListComponent,
    CulinaryChannelCreateComponent,
    CulinaryChannelEditComponent,
    DishListComponent,
    DishCreateComponent,
    DishEditComponent,
    RecipeListComponent,
    RecipeCreateComponent,
    RecipeEditComponent,
    RecipeDetailComponent,
    EpisodeListComponent,
    EpisodeCreateComponent,
    EpisodeEditComponent,
    CernovicComponent,
    RecipeLibraryComponent,
    BookLibraryComponent,
    RestaurantLibraryComponent,
    BookDetailComponent,
    DishDetailComponent,
    TelephoneCreateComponent,
    TelephoneEditComponent,
    TelephoneListComponent,
    RestaurantCreateComponent,
    RestaurantEditComponent,
    RestaurantListComponent,
    LoginComponent,
    RegisterComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    //ReactiveFormsModule.withConfig({ warnOnNgModelWithFormControl: 'never' }),
    ReactiveFormsModule,
  ],
  providers: [
    AddressService,
    AuthorService,
    BookService,
    CommentService,
    CookingStageService,
    CulinaryChannelService,
    DishService,
    EpisodeService,
    ImageService,
    IngredientService,
    OrganicMatterService,
    RecipeService,
    RestaurantService,
    SubscriberService,
    TagService,
    TelephoneService,
    RecipeOrganicMatterService,
    AuthService,
    AuthGuardService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
