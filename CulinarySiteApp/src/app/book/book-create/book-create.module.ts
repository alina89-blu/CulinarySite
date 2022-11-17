import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { BookCreateRoutingModule } from './book-create-routing.module';
import { BookCreateComponent } from './book-create.component';
import { MatSelectModule } from '@angular/material/select';

@NgModule({
  declarations: [BookCreateComponent],
  imports: [
    BookCreateRoutingModule,
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    ReactiveFormsModule,
  ],
  exports: [BookCreateComponent],
})
export class BookCreateModule {}
