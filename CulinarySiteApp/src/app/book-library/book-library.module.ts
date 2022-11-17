import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatGridListModule } from '@angular/material/grid-list';
import { BookLibraryRoutingModule } from './book-library-routing.module';
import { BookLibraryComponent } from './book-library.component';
import { MatCardModule } from '@angular/material/card';

@NgModule({
  declarations: [BookLibraryComponent],
  imports: [
    BookLibraryRoutingModule,
    CommonModule,
    MatGridListModule,
    MatCardModule,
  ],
  exports: [BookLibraryComponent],
})
export class BookLibraryModule {}
