import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { AuthorListComponent } from './author-list.component';
import { AuthorListRoutingModule } from './author-list-routing.module';

@NgModule({
  declarations: [AuthorListComponent],
  imports: [
    AuthorListRoutingModule,
    CommonModule,
    MatButtonModule,
    MatTableModule,
  ],
  exports: [AuthorListComponent],
})
export class AuthorListModule {}
