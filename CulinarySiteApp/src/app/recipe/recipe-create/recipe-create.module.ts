import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { RecipeCreateRoutingModule } from './recipe-create-routing.module';
import { RecipeCreateComponent } from './recipe-create.component';
import { MatSelectModule } from '@angular/material/select';

@NgModule({
  declarations: [RecipeCreateComponent],
  imports: [
    RecipeCreateRoutingModule,
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
    MatSelectModule,
  ],
  exports: [RecipeCreateComponent],
})
export class RecipeCreateModule {}
