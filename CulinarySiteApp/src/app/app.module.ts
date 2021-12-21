import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

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

import { AppComponent } from './app.component';
import { AddressListComponent } from './address/address-list/address-list.component';
import { AddressEditComponent } from './address/address-edit/address-edit.component';
import { AddressCreateComponent } from './address/address-create/address-create.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AuthorListComponent } from './author/author-list/author-list.component';
import { AuthorCreateComponent } from './author/author-create/author-create.component';
import { AuthorEditComponent } from './author/author-edit/author-edit.component';

const appRoutes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'address', component: AddressListComponent },
  { path: 'editAddress/:id', component: AddressEditComponent },
  { path: 'createAddress', component: AddressCreateComponent },
  { path: 'author', component: AuthorListComponent },
  { path: 'createAuthor', component: AuthorCreateComponent },
  { path: 'editAuthor/:id', component: AuthorEditComponent },
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
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot(appRoutes),
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
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
