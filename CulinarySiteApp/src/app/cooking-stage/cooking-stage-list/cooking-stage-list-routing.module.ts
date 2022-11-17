import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CookingStageListComponent } from './cooking-stage-list.component';

const routes: Routes = [{ path: '', component: CookingStageListComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CookingStageListRoutingModule {}
