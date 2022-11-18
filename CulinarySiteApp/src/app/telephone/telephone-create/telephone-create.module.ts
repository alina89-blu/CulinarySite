import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { TelephoneCreateRoutingModule } from './telephone-create-routing.module';
import { TelephoneCreateComponent } from './telephone-create.component';
import { MatSelectModule } from '@angular/material/select';

@NgModule({
  declarations: [TelephoneCreateComponent],
  imports: [
    TelephoneCreateRoutingModule,
    CommonModule,
    FormsModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    ReactiveFormsModule,
  ],
  exports: [TelephoneCreateComponent],
})
export class TelephoneCreateModule {}
