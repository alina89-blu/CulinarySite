import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from './material/material.module';

import { AddressService } from './services/address.service';
import { AuthorService } from './services/author.service';
import { BookService } from './services/book.service';
import { CommentService } from './services/comment.service';
import { CookingStageService } from './services/cooking-stage.service';
import { CulinaryChannelService } from './services/culinary-channel.service';
import { DishService } from './services/dish.service';
import { EpisodeService } from './services/episode.service';
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
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
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
import { RestaurantLibraryComponent } from './restaurant-library/restaurant-library.component';
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
import { EpisodeDetailComponent } from './episode/episode-detail/episode-detail.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EpisodesLibraryComponent } from './episodes-library/episodes-library.component';
import { TokenInterceptorService } from './services/token-interceptor.service';

//import { AppRoutingModule } from './app-routing.module';

const appRoutes: Routes = [
  { path: '', component: HomeComponent },

  {
    path: 'createAddress',
    loadChildren: () =>
      import('./address/address-create/address-create.module').then(
        (m) => m.AddressCreateModule
      ),
  },

  {
    path: 'editAddress',
    loadChildren: () =>
      import('./address/address-edit/address-edit.module').then(
        (m) => m.AddressEditModule
      ),
  },

  {
    path: 'address',
    loadChildren: () =>
      import('./address/address-list/address-list.module').then(
        (m) => m.AddressListModule
      ),
  },

  {
    path: 'createAuthor',
    loadChildren: () =>
      import('./author/author-create/author-create.module').then(
        (m) => m.AuthorCreateModule
      ),
  },

  {
    path: 'editAuthor',
    loadChildren: () =>
      import('./author/author-edit/author-edit.module').then(
        (m) => m.AuthorEditModule
      ),
  },

  {
    path: 'author',
    loadChildren: () =>
      import('./author/author-list/author-list.module').then(
        (m) => m.AuthorListModule
      ),
  },

  {
    path: 'createBook',
    loadChildren: () =>
      import('./book/book-create/book-create.module').then(
        (m) => m.BookCreateModule
      ),
    canActivate: [AuthGuardService],
  },

  {
    path: 'book',
    loadChildren: () =>
      import('./book/book-list/book-list.module').then((m) => m.BookListModule),
  },

  {
    path: 'book',
    loadChildren: () =>
      import('./book/book-detail/book-detail.module').then(
        (m) => m.BookDetailModule
      ),
  },

  {
    path: 'editBook',
    loadChildren: () =>
      import('./book/book-edit/book-edit.module').then((m) => m.BookEditModule),
  },

  {
    path: 'bookLibrary',
    loadChildren: () =>
      import('./book-library/book-library.module').then(
        (m) => m.BookLibraryModule
      ),
  },

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
  { path: 'restaurantLibrary', component: RestaurantLibraryComponent },
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
  { path: 'episode/:id', component: EpisodeDetailComponent },

  //
];

@NgModule({
  declarations: [
    AppComponent,
    //AddressListComponent,
    //  AddressEditComponent,
    //AddressCreateComponent,
    NavMenuComponent,
    HomeComponent,
    // AuthorListComponent,
    // AuthorCreateComponent,
    //AuthorEditComponent,
    // BookListComponent,
    // BookEditComponent,
    //BookCreateComponent,
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
    // BookLibraryComponent,
    RestaurantLibraryComponent,
    // BookDetailComponent,
    DishDetailComponent,
    TelephoneCreateComponent,
    TelephoneEditComponent,
    TelephoneListComponent,
    RestaurantCreateComponent,
    RestaurantEditComponent,
    RestaurantListComponent,
    LoginComponent,
    RegisterComponent,
    EpisodeDetailComponent,
    EpisodesLibraryComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    //ReactiveFormsModule.withConfig({ warnOnNgModelWithFormControl: 'never' }),
    ReactiveFormsModule,
    MaterialModule,
    BrowserAnimationsModule,
    // AppRoutingModule,
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
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptorService,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
