import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { AuthorCreateRoutingModule } from './author-create-routing.module';

import { AuthorCreateComponent } from './author-create.component';

@NgModule({
  declarations: [AuthorCreateComponent],
  imports: [
    AuthorCreateRoutingModule,
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    ReactiveFormsModule,
  ],
  exports: [AuthorCreateComponent],
})
export class AuthorCreateModule {}
