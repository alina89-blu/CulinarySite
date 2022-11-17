import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookLibraryComponent } from './book-library.component';

const routes: Routes = [{ path: '', component: BookLibraryComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class BookLibraryRoutingModule {}
