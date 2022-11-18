import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { TelephoneEditRoutingModule } from './telephone-edit-routing.module';
import { TelephoneEditComponent } from './telephone-edit.component';

@NgModule({
  declarations: [TelephoneEditComponent],
  imports: [
    TelephoneEditRoutingModule,
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    ReactiveFormsModule,
  ],
  exports: [TelephoneEditComponent],
})
export class TelephoneEditModule {}
