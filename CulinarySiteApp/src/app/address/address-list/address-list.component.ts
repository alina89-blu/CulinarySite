import { Component, OnInit } from '@angular/core';
import { AddressService } from '../../services/address.service';
import { AddressListModel } from 'src/app/viewmodels/address/address-list-model.class';
import { IAddressListModel } from 'src/app/interfaces/address/address-list-model.interface';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-address',
  templateUrl: './address-list.component.html',
  styleUrls: ['./address-list.component.css'],
  providers: [AddressService],
})
export class AddressListComponent implements OnInit {
  public addresses: AddressListModel[] = [];
  public displayedColumns: string[] = ['id', 'name', 'action'];
  public dataSource: MatTableDataSource<IAddressListModel>;

  constructor(private readonly addressService: AddressService) {}

  public ngOnInit(): void {
    this.getAddressList();
  }

  public getAddressList(): void {
    this.addressService
      .getAddressList()
      .subscribe((data: IAddressListModel[]) => {
        this.addresses = data.map((x) => new AddressListModel(x));
        this.dataSource = new MatTableDataSource<IAddressListModel>(
          this.addresses
        );
      });
  }

  public deleteAddress(id: number): void {
    this.addressService.delete(id).subscribe(() => this.getAddressList());
  }
}
