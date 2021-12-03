import { Component, OnInit } from '@angular/core';
import { Address } from '../../classes/address';
import { AddressService } from '../../services/address.service';

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