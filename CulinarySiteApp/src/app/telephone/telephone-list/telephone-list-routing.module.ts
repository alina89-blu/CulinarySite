import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TelephoneListComponent } from './telephone-list.component';

const routes: Routes = [{ path: '', component: TelephoneListComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TelephoneListRoutingModule {}
