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
import { RecipeIngredientService } from './services/recipe-ingredient.service';
import { RecipeOrganicMatterService } from './services/recipe-organic-matter.service';

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
import { BlaComponent } from './bla.component';
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
import { EpisodeListComponent } from './episode/episode-list/episode-list.component';
import { EpisodeCreateComponent } from './episode/episode-create/episode-create.component';
import { EpisodeEditComponent } from './episode/episode-edit/episode-edit.component';
import { IngredientListComponent } from './ingredient/ingredient-list/ingredient-list.component';
import { IngredientCreateComponent } from './ingredient/ingredient-create/ingredient-create.component';
import { IngredientEditComponent } from './ingredient/ingredient-edit/ingredient-edit.component';

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
  { path: 'createBook', component: BookCreateComponent },
  { path: 'bla', component: BlaComponent },
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
  { path: 'episode', component: EpisodeListComponent },
  { path: 'createEpisode', component: EpisodeCreateComponent },
  { path: 'editEpisode/:id', component: EpisodeEditComponent },
  { path: 'ingredient', component: IngredientListComponent },
  { path: 'createIngredient', component: IngredientCreateComponent },
  { path: 'editIngredient/:id', component: IngredientEditComponent },
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
    BlaComponent,
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
    EpisodeListComponent,
    EpisodeCreateComponent,
    EpisodeEditComponent,
    IngredientListComponent,
    IngredientCreateComponent,
    IngredientEditComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
    ReactiveFormsModule.withConfig({ warnOnNgModelWithFormControl: 'never' }),
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
    RecipeIngredientService,
    RecipeOrganicMatterService,
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
