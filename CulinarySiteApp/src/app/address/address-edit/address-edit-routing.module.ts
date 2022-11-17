import { NgModule } from '@angular/core';
import { AddressEditComponent } from './address-edit.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [{ path: ':id', component: AddressEditComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AddressEditRoutingModule {}
