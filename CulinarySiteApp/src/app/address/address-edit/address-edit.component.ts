import { Component, OnInit } from '@angular/core';
import { ActivatedRoute,Router } from '@angular/router';
import { Address } from 'src/app/classes/address.class';
import { AddressService } from 'src/app/services/address.service';

@Component({
  selector: 'app-address-edit',
  templateUrl: './address-edit.component.html',
  styleUrls: ['./address-edit.component.css']
})
export class AddressEditComponent implements OnInit {

  id:number;
  address:Address=new Address();

  constructor(private addressService:AddressService,private router: Router, activeRoute: ActivatedRoute) 
  {
    this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
  }

  ngOnInit()
  {
    if(this.id)
    {
     this.addressService.GetAddress(this.id).subscribe((data:Address)=>this.address=data);
    }
  }
  UpdateAddress(){
    this.addressService.UpdateAddress(this.address).subscribe(data => this.router.navigateByUrl("/"));
  }


}
