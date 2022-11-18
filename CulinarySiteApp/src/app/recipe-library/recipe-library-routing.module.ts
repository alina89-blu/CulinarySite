import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RecipeLibraryComponent } from './recipe-library.component';

const routes: Routes = [{ path: '', component: RecipeLibraryComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class RecipeLibraryRoutingModule {}
