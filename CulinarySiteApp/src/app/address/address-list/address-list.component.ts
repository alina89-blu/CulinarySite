import { Component, OnInit } from '@angular/core';
import { Address } from '../classes/address';
import { AddressService } from '../services/address.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.css'],
  providers:[AddressService]
})

export class AddressComponent  {

  addresses:Address[]=[];
  address:Address=new Address();
  id:number;

  load:boolean=true;
  
  constructor(private addressService:AddressService,private activeRoute: ActivatedRoute) {
    this.id=Number.parseInt(activeRoute.snapshot.params["id"]);
   }
  

  /*ngOnInit(){
    this.GetAddressList();
  }*/
  GetAddressList(){
   
    this.addressService.GetAddressList().subscribe(data=>data=this.addresses);    
}

GetAddress(){
  if (this.id)
      this.addressService.GetAddress(this.id).subscribe(data=>data=this.address);
}
CreateAddress(address:Address){
this.addressService.CreateAddress(address).subscribe(data=>this.GetAddressList());
}

UpdateAddress(address:Address){
this.addressService.UpdateAddress(address).subscribe(data=>this.GetAddressList());
}
DeleteAddress(id:number){
this.addressService.DeleteAddress(id).subscribe(data=>this.GetAddressList());
}


}