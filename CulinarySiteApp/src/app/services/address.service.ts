import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Address } from '../classes/address';


@Injectable()

export class AddressService {
public url:string="/api/addresses";

  constructor(private http:HttpClient){}
   
   GetAddressList(){
   return this.http.get(this.url);
   }
   GetAddress(id:number){
   return this.http.get(this.url+'/'+id);
   }
   CreateAddress(address:Address){
   return this.http.post(this.url,address);
   }
   UpdateAddress(address:Address){
   return this.http.put(this.url,address);
   }
   DeleteAddress(address:Address){
   return this.http.delete(this.url+'/'+address.id);
   }

  }