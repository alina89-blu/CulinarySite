import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { AuthorEditRoutingModule } from './author-edit-routing.module';
import { AuthorEditComponent } from './author-edit.component';

@NgModule({
  declarations: [AuthorEditComponent],
  imports: [
    AuthorEditRoutingModule,
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
  ],
  exports: [AuthorEditComponent],
})
export class AuthorEditModule {}
