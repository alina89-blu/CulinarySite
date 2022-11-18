import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RestaurantLibraryComponent } from './restaurant-library.component';
import { RestaurantLibraryRoutingModule } from './restaurant-library-routing.module';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';

@NgModule({
  declarations: [RestaurantLibraryComponent],
  imports: [
    RestaurantLibraryRoutingModule,
    CommonModule,
    MatCardModule,
    MatIconModule,
  ],
  exports: [RestaurantLibraryComponent],
})
export class RestaurantLibraryModule {}
