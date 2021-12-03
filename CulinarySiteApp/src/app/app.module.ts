import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AddressService } from './services/address.service';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { AddressListComponent } from './address/address-list/address-list.component';
import { AddressCreateComponent } from './address-create/address-create.component';



const appRoutes: Routes = [

  
  { path: '', component: AddressListComponent }
  
        
];


@NgModule({
  declarations: [
    AppComponent,
    AddressListComponent,
    AddressCreateComponent,
   
   
  ],
  imports: [
    BrowserModule,FormsModule,HttpClientModule,RouterModule.forRoot(appRoutes)
  ],
  providers: [AddressService],
  bootstrap: [AppComponent]
})
export class AppModule { }
