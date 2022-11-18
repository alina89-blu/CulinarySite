import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TelephoneEditComponent } from './telephone-edit.component';

const routes: Routes = [{ path: ':id', component: TelephoneEditComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TelephoneEditRoutingModule {}
