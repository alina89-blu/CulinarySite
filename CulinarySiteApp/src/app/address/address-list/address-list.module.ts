import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddressListComponent } from './address-list.component';
import { AddressListRoutingModule } from './address-list-routing.module';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';

@NgModule({
  declarations: [AddressListComponent],
  imports: [
    AddressListRoutingModule,
    CommonModule,
    MatButtonModule,
    MatTableModule,
  ],
  exports: [AddressListComponent],
})
export class AddressListModule {}
