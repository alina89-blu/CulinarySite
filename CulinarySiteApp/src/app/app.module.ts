import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { MaterialModule } from './material/material.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AddressService } from './services/address.service';
import { AuthorService } from './services/author.service';
import { BookService } from './services/book.service';
import { CommentService } from './services/comment.service';
import { CookingStageService } from './services/cooking-stage.service';
import { DishService } from './services/dish.service';
import { IngredientService } from './services/ingredient.service';
import { OrganicMatterService } from './services/organic-matter.service';
import { RecipeService } from './services/recipe.service';
import { RestaurantService } from './services/restaurant.service';
import { TagService } from './services/tag.service';
import { TelephoneService } from './services/telephone.service';
import { AuthService } from './services/auth.service';
import { AuthGuardService } from './services/auth-guard.service';
import { TokenInterceptorService } from './services/token-interceptor.service';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';

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
    path: 'bookDetail',
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

  {
    path: 'createCookingStage',
    loadChildren: () =>
      import(
        './cooking-stage/cooking-stage-create/cooking-stage-create.module'
      ).then((m) => m.CookingStageCreateModule),
  },

  {
    path: 'editCookingStage',
    loadChildren: () =>
      import(
        './cooking-stage/cooking-stage-edit/cooking-stage-edit.module'
      ).then((m) => m.CookingStageEditModule),
  },

  {
    path: 'cookingStage',
    loadChildren: () =>
      import(
        './cooking-stage/cooking-stage-list/cooking-stage-list.module'
      ).then((m) => m.CookingStageListModule),
  },

  {
    path: 'createDish',
    loadChildren: () =>
      import('./dish/dish-create/dish-create.module').then(
        (m) => m.DishCreateModule
      ),
  },

  {
    path: 'dish',
    loadChildren: () =>
      import('./dish/dish-list/dish-list.module').then((m) => m.DishListModule),
  },

  {
    path: 'dishDetail',
    loadChildren: () =>
      import('./dish/dish-detail/dish-detail.module').then(
        (m) => m.DishDetailModule
      ),
  },

  {
    path: 'editDish',
    loadChildren: () =>
      import('./dish/dish-edit/dish-edit.module').then((m) => m.DishEditModule),
  },

  {
    path: 'createRecipe',
    loadChildren: () =>
      import('./recipe/recipe-create/recipe-create.module').then(
        (m) => m.RecipeCreateModule
      ),
  },

  {
    path: 'recipe',
    loadChildren: () =>
      import('./recipe/recipe-list/recipe-list.module').then(
        (m) => m.RecipeListModule
      ),
  },

  {
    path: 'recipeDetail',
    loadChildren: () =>
      import('./recipe/recipe-detail/recipe-detail.module').then(
        (m) => m.RecipeDetailModule
      ),
  },

  {
    path: 'editRecipe',
    loadChildren: () =>
      import('./recipe/recipe-edit/recipe-edit.module').then(
        (m) => m.RecipeEditModule
      ),
  },

  {
    path: 'recipeLibrary',
    loadChildren: () =>
      import('./recipe-library/recipe-library.module').then(
        (m) => m.RecipeLibraryModule
      ),
  },

  {
    path: 'createRestaurant',
    loadChildren: () =>
      import('./restaurant/restaurant-create/restaurant-create.module').then(
        (m) => m.RestaurantCreateModule
      ),
  },

  {
    path: 'restaurant',
    loadChildren: () =>
      import('./restaurant/restaurant-list/restaurant-list.module').then(
        (m) => m.RestaurantListModule
      ),
  },

  {
    path: 'editRestaurant',
    loadChildren: () =>
      import('./restaurant/restaurant-update/restaurant-edit.module').then(
        (m) => m.RestaurantEditModule
      ),
  },

  {
    path: 'restaurantLibrary',
    loadChildren: () =>
      import('./restaurant-library/restaurant-library.module').then(
        (m) => m.RestaurantLibraryModule
      ),
  },

  {
    path: 'createTelephone',
    loadChildren: () =>
      import('./telephone/telephone-create/telephone-create.module').then(
        (m) => m.TelephoneCreateModule
      ),
  },

  {
    path: 'editTelephone',
    loadChildren: () =>
      import('./telephone/telephone-edit/telephone-edit.module').then(
        (m) => m.TelephoneEditModule
      ),
  },

  {
    path: 'telephone',
    loadChildren: () =>
      import('./telephone/telephone-list/telephone-list.module').then(
        (m) => m.TelephoneListModule
      ),
  },

  {
    path: 'login',
    loadChildren: () =>
      import('./login/login.module').then((m) => m.LoginModule),
  },

  {
    path: 'register',
    loadChildren: () =>
      import('./register/register.module').then((m) => m.RegisterModule),
  },
];

@NgModule({
  declarations: [AppComponent, NavMenuComponent, HomeComponent],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
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
    DishService,
    IngredientService,
    OrganicMatterService,
    RecipeService,
    RestaurantService,
    TagService,
    TelephoneService,
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
