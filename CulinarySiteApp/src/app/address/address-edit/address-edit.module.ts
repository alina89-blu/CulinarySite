import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddressEditComponent } from './address-edit.component';
import { AddressEditRoutingModule } from './address-edit-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@NgModule({
  declarations: [AddressEditComponent],
  imports: [
    AddressEditRoutingModule,
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
  ],
  exports: [AddressEditComponent],
})
export class AddressEditModule {}
