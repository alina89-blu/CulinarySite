import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { RecipeEditRoutingModule } from './recipe-edit-routing.module';
import { RecipeEditComponent } from './recipe-edit.component';

@NgModule({
  declarations: [RecipeEditComponent],
  imports: [
    RecipeEditRoutingModule,
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    MatSelectModule,
  ],
  exports: [RecipeEditComponent],
})
export class RecipeEditModule {}
