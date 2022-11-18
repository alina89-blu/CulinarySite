import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RestaurantLibraryComponent } from './restaurant-library.component';

const routes: Routes = [{ path: '', component: RestaurantLibraryComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class RestaurantLibraryRoutingModule {}
