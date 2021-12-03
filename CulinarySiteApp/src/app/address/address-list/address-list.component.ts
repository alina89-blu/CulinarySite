import { Component, OnInit } from '@angular/core';
import { AddressService } from '../../services/address.service';
import { Address } from 'src/app/classes/address.class';

@Component({
  selector: 'app-address',
  templateUrl: './address-list.component.html',
  styleUrls: ['./address-list.component.css'],
  providers:[AddressService]
})

export class AddressListComponent implements OnInit  {

  addresses:Address[]=[];
  
   constructor(private addressService:AddressService) {}
  

  ngOnInit()
  {
    this.GetAddressList();
  }
  GetAddressList()
  {        
    this.addressService.GetAddressList().subscribe((data:any)=>this.addresses=data);    
  }
  DeleteAddress(address:Address)
  {
    this.addressService.DeleteAddress(address).subscribe(data=>this.GetAddressList());
  }





}