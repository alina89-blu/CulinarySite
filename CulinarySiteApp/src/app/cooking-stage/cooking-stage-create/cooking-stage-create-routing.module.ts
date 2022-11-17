import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CookingStageCreateComponent } from './cooking-stage-create.component';

const routes: Routes = [{ path: '', component: CookingStageCreateComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class CookingStageCreateRoutingModule {}
