import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { BookDetailRoutingModule } from './book-detail-routing.module';
import { BookDetailComponent } from './book-detail.component';

@NgModule({
  declarations: [BookDetailComponent],
  imports: [
    BookDetailRoutingModule,
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
  ],
  exports: [BookDetailComponent],
})
export class BookDetailModule {}
