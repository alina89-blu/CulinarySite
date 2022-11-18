import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatInputModule } from '@angular/material/input';
import { RecipeListComponent } from './recipe-list.component';
import { RecipeListRoutingModule } from './recipe-list-routing.module';

@NgModule({
  declarations: [RecipeListComponent],
  imports: [
    RecipeListRoutingModule,
    CommonModule,
    MatButtonModule,
    MatTableModule,
    MatFormFieldModule,
    FormsModule,
    MatIconModule,
    MatSortModule,
    MatPaginatorModule,
    MatInputModule,
  ],
  exports: [RecipeListComponent],
})
export class RecipeListModule {}
