import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { AddressEditComponent } from './address-edit.component';

const routes: Routes = [{ path: '', component: AddressEditComponent }];

@NgModule({
  declarations: [AddressEditComponent],
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule, AddressEditComponent],
})
export class AddressEditModule {}
