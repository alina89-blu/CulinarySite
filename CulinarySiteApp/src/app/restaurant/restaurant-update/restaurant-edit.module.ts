import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { RestaurantEditRoutingModule } from './restaurant-edit-routing.module';
import { RestaurantEditComponent } from './restaurant-edit.component';

@NgModule({
  declarations: [RestaurantEditComponent],
  imports: [
    RestaurantEditRoutingModule,
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    ReactiveFormsModule,
  ],
  exports: [RestaurantEditComponent],
})
export class RestaurantEditModule {}
