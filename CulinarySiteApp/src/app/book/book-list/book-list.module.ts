import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { BookListRoutingModule } from './book-list-routing.module';
import { BookListComponent } from './book-list.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormsModule } from '@angular/forms';
import { MatIconModule } from '@angular/material/icon';
import { MatSortModule } from '@angular/material/sort';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatInputModule } from '@angular/material/input';

@NgModule({
  declarations: [BookListComponent],
  imports: [
    BookListRoutingModule,
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
  exports: [BookListComponent],
})
export class BookListModule {}
