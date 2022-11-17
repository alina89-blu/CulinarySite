import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { CookingStageCreateRoutingModule } from './cooking-stage-create-routing.module';
import { CookingStageCreateComponent } from './cooking-stage-create.component';
import { MatSelectModule } from '@angular/material/select';

@NgModule({
  declarations: [CookingStageCreateComponent],
  imports: [
    CookingStageCreateRoutingModule,
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatSelectModule,
    MatInputModule,
    ReactiveFormsModule,
  ],
  exports: [CookingStageCreateComponent],
})
export class CookingStageCreateModule {}
