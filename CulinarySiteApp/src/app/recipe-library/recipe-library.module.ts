import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RecipeLibraryComponent } from './recipe-library.component';
import { RecipeLibraryRoutingModule } from './recipe-library-routing.module';
import { MatGridListModule } from '@angular/material/grid-list';

@NgModule({
  declarations: [RecipeLibraryComponent],
  imports: [RecipeLibraryRoutingModule, CommonModule, MatGridListModule],
  exports: [RecipeLibraryComponent],
})
export class RecipeLibraryModule {}
