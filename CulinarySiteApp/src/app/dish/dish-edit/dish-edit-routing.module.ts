import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DishEditComponent } from './dish-edit.component';

const routes: Routes = [{ path: ':id', component: DishEditComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DishEditRoutingModule {}
