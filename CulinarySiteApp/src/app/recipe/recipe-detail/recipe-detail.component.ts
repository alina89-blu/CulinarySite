import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IRecipeImageListModel } from 'src/app/interfaces/image/recipe-image/recipe-image-list-model.interface';
import { IRecipeDetailModel } from 'src/app/interfaces/recipe/recipe-detail-model.interface';
import { ImageService } from 'src/app/services/image.service';
import { RecipeService } from 'src/app/services/recipe.service';
import { RecipeImageListModel } from 'src/app/viewmodels/image/recipe-image/recipe-image-list-model.class';
import { RecipeDetailModel } from 'src/app/viewmodels/recipe/recipe-detail-model.class';

@Component({
  selector: 'app-recipe-detail',
  templateUrl: './recipe-detail.component.html',
  styleUrls: ['./recipe-detail.component.css'],
})
export class RecipeDetailComponent implements OnInit {
  id: number;
  recipeDetailModel: RecipeDetailModel = new RecipeDetailModel();
  images: RecipeImageListModel[] = [];
  //  loaded: boolean = false;
  constructor(
    private recipeService: RecipeService,
    private imageService: ImageService,
    activeRoute: ActivatedRoute,
    private http: HttpClient
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);
  }

  public ngOnInit(): void {
    if (this.id) {
      this.recipeService
        .getRecipe(this.id, true)
        .subscribe(
          (data: IRecipeDetailModel) =>
            (this.recipeDetailModel = new RecipeDetailModel(data))
        );
    }
    //this.getRecipeImageList();
  }

  /*public getRecipeImageList(): void {
    this.imageService
      .getRecipeImageList(true)
      .subscribe(
        (data: IRecipeImageListModel[]) =>
          (this.images = data.map((x) => new RecipeImageListModel(x)))
      );
  }*/
}
