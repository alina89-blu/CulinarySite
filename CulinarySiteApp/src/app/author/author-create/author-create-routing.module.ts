import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthorCreateComponent } from './author-create.component';

const routes: Routes = [{ path: '', component: AuthorCreateComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AuthorCreateRoutingModule {}
