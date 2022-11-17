import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { BookEditRoutingModule } from './book-edit-routing.module';
import { BookEditComponent } from './book-edit.component';
import { MatSelectModule } from '@angular/material/select';

@NgModule({
  declarations: [BookEditComponent],
  imports: [
    BookEditRoutingModule,
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    ReactiveFormsModule,
  ],
  exports: [BookEditComponent],
})
export class BookEditModule {}
