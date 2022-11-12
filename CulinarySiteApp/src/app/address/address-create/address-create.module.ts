import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddressCreateComponent } from './address-create.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: '',
    component: AddressCreateComponent,
  },
];

@NgModule({
  declarations: [AddressCreateComponent],
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule, AddressCreateComponent],
})
export class AddressCreateModule {}
