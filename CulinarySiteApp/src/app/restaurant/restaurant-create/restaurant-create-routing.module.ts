import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RestaurantCreateComponent } from './restaurant-create.component';

const routes: Routes = [{ path: '', component: RestaurantCreateComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class RestaurantCreateRoutingModule {}
