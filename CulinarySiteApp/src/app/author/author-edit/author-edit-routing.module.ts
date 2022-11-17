import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorEditComponent } from './author-edit.component';

const routes: Routes = [{ path: ':id', component: AuthorEditComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AuthorEditRoutingModule {}
