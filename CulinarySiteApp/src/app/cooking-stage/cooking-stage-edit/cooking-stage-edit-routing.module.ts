import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CookingStageEditComponent } from './cooking-stage-edit.component';

const routes: Routes = [{ path: ':id', component: CookingStageEditComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CookingStageEditRoutingModule {}
