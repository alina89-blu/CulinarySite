import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { DishCreateRoutingModule } from './dish-create-routing.module';
import { DishCreateComponent } from './dish-create.component';
import { MatSelectModule } from '@angular/material/select';

@NgModule({
  declarations: [DishCreateComponent],
  imports: [
    DishCreateRoutingModule,
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    ReactiveFormsModule,
  ],
  exports: [DishCreateComponent],
})
export class DishCreateModule {}
