import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { DishDetailRoutingModule } from './dish-detail-routing.module';
import { DishDetailComponent } from './dish-detail.component';

@NgModule({
  declarations: [DishDetailComponent],
  imports: [DishDetailRoutingModule, CommonModule, MatButtonModule],
  exports: [DishDetailComponent],
})
export class DishDetailModule {}
