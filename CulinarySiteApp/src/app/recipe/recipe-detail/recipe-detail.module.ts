import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RecipeDetailRoutingModule } from './recipe-detail-routing.module';
import { RecipeDetailComponent } from './recipe-detail.component';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  declarations: [RecipeDetailComponent],
  imports: [RecipeDetailRoutingModule, CommonModule, MatIconModule],
  exports: [RecipeDetailComponent],
})
export class RecipeDetailModule {}
