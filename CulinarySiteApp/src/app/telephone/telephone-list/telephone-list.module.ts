import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { TelephoneListComponent } from './telephone-list.component';
import { TelephoneListRoutingModule } from './telephone-list-routing.module';

@NgModule({
  declarations: [TelephoneListComponent],
  imports: [
    TelephoneListRoutingModule,
    CommonModule,
    MatButtonModule,
    MatTableModule,
  ],
  exports: [TelephoneListComponent],
})
export class TelephoneListModule {}
