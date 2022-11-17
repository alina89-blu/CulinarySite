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
import { DishService } from './services/dish.service';
import { IngredientService } from './services/ingredient.service';
import { OrganicMatterService } from './services/organic-matter.service';
import { RecipeService } from './services/recipe.service';
import { RestaurantService } from './services/restaurant.service';
import { TagService } from './services/tag.service';
import { TelephoneService } from './services/telephone.service';
import { AuthService } from './services/auth.service';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CookingStageListComponent } from './cooking-stage/cooking-stage-list/cooking-stage-list.component';
import { CookingStageEditComponent } from './cooking-stage/cooking-stage-edit/cooking-stage-edit.component';

import { CookingStageListModule } from './cooking-stage/cooking-stage-list/cooking-stage-list.module';

import { CookingStageEditModule } from './cooking-stage/cooking-stage-edit/cooking-stage-edit.module';

import { DishListComponent } from './dish/dish-list/dish-list.component';

import { DishListModule } from './dish/dish-list/dish-list.module';
import { DishListModel } from './viewmodels/dish/dish-list-model.class';
import { DishCreateComponent } from './dish/dish-create/dish-create.component';
import { DishCreateModule } from './dish/dish-create/dish-create.module';
import { DishEditComponent } from './dish/dish-edit/dish-edit.component';
import { DishEditModule } from './dish/dish-edit/dish-edit.module';
import { RecipeListComponent } from './recipe/recipe-list/recipe-list.component';
import { RecipeCreateComponent } from './recipe/recipe-create/recipe-create.component';

import { RecipeCreateModule } from './recipe/recipe-create/recipe-create.module';
import { RecipeEditComponent } from './recipe/recipe-edit/recipe-edit.component';
import { RecipeDetailComponent } from './recipe/recipe-detail/recipe-detail.component';

import { CernovicComponent } from './cernovic/cernovic.component';
import { RecipeLibraryComponent } from './recipe-library/recipe-library.component';
import { RestaurantLibraryComponent } from './restaurant-library/restaurant-library.component';
import { DishDetailComponent } from './dish/dish-detail/dish-detail.component';

import { DishDetailModule } from './dish/dish-detail/dish-detail.module';
import { TelephoneCreateComponent } from './telephone/telephone-create/telephone-create.component';
import { TelephoneEditComponent } from './telephone/telephone-edit/telephone-edit.component';
import { TelephoneListComponent } from './telephone/telephone-list/telephone-list.component';
import { RestaurantCreateComponent } from './restaurant/restaurant-create/restaurant-create.component';
import { RestaurantEditComponent } from './restaurant/restaurant-update/restaurant-edit.component';
import { RestaurantListComponent } from './restaurant/restaurant-list/restaurant-list.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthGuardService } from './services/auth-guard.service';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
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
    path: 'dish',
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

  { path: 'recipe', component: RecipeListComponent },
  { path: 'editRecipe/:id', component: RecipeEditComponent },
  { path: 'recipe/:id', component: RecipeDetailComponent },

  { path: 'recipeLibrary', component: RecipeLibraryComponent },
  { path: 'restaurantLibrary', component: RestaurantLibraryComponent },

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
    NavMenuComponent,
    HomeComponent,

    RecipeListComponent,
    //RecipeCreateComponent,
    RecipeEditComponent,
    RecipeDetailComponent,

    CernovicComponent,
    RecipeLibraryComponent,
    RestaurantLibraryComponent,
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
