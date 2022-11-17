import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { CookingStageEditRoutingModule } from './cooking-stage-edit-routing.module';
import { CookingStageEditComponent } from './cooking-stage-edit.component';

@NgModule({
  declarations: [CookingStageEditComponent],
  imports: [
    CookingStageEditRoutingModule,
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    ReactiveFormsModule,
  ],
  exports: [CookingStageEditComponent],
})
export class CookingStageEditModule {}
