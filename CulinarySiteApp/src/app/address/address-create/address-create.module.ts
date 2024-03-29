import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { AddressCreateRoutingModule } from './address-create-routing.module';
import { AddressCreateComponent } from './address-create.component';

@NgModule({
  declarations: [AddressCreateComponent],
  imports: [
    AddressCreateRoutingModule,
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
  ],
  exports: [AddressCreateComponent],
})
export class AddressCreateModule {}
