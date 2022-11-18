import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { RestaurantCreateRoutingModule } from './restaurant-create-routing.module';
import { RestaurantCreateComponent } from './restaurant-create.component';
import { MatSelectModule } from '@angular/material/select';

@NgModule({
  declarations: [RestaurantCreateComponent],
  imports: [
    RestaurantCreateRoutingModule,
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    ReactiveFormsModule,
  ],
  exports: [RestaurantCreateComponent],
})
export class RestaurantCreateModule {}
