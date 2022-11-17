import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { DishListComponent } from './dish-list.component';
import { DishListRoutingModule } from './dish-list-routing.module';

@NgModule({
  declarations: [DishListComponent],
  imports: [
    DishListRoutingModule,
    CommonModule,
    MatButtonModule,
    MatTableModule,
  ],
  exports: [DishListComponent],
})
export class DishListModule {}
