import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { RestaurantListComponent } from './restaurant-list.component';
import { RestaurantListRoutingModule } from './restaurant-list-routing.module';

@NgModule({
  declarations: [RestaurantListComponent],
  imports: [
    RestaurantListRoutingModule,
    CommonModule,
    MatButtonModule,
    MatTableModule,
  ],
  exports: [RestaurantListComponent],
})
export class RestaurantListModule {}
