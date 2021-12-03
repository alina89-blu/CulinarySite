import { Component, OnInit } from '@angular/core';
import { AddressService } from 'src/app/services/address.service';
import { Address } from 'src/app/classes/address';
import { Router } from '@angular/router';

@Component({
  selector: 'app-address-create',
  templateUrl: './address-create.component.html',
  styleUrls: ['./address-create.component.css']
})
export class AddressCreateComponent {
  
  address:Address=new Address();
  constructor(private addressService:AddressService,private router: Router) { }

 
  CreateAddress()
  {
   this.addressService.CreateAddress(this.address).subscribe(data=>this.router.navigateByUrl("/"));
  }

}
