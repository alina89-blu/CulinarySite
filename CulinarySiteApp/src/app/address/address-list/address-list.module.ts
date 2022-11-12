import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddressListComponent } from './address-list.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [{ path: '', component: AddressListComponent }];

@NgModule({
  declarations: [AddressListComponent],
  imports: [CommonModule, RouterModule.forChild(routes)],
  exports: [RouterModule, AddressListComponent],
})
export class AddressListModule {}
