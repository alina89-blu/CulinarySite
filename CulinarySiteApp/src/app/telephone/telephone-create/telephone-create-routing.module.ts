import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TelephoneCreateComponent } from './telephone-create.component';

const routes: Routes = [{ path: '', component: TelephoneCreateComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class TelephoneCreateRoutingModule {}
