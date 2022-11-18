import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ITelephoneListModel } from 'src/app/interfaces/telephone/telephone-list-model.interface';
import { TelephoneService } from 'src/app/services/telephone.service';
import { TelephoneListModel } from 'src/app/viewmodels/telephone/telephone-list-model.class';

@Component({
  selector: 'app-telephone-list',
  templateUrl: './telephone-list.component.html',
  styleUrls: ['./telephone-list.component.css'],
})
export class TelephoneListComponent implements OnInit {
  public telephones: TelephoneListModel[] = [];
  public displayedColumns: string[] = [
    'id',
    'number',
    'restaurantName',
    'actions',
  ];
  public dataSource: MatTableDataSource<ITelephoneListModel>;

  constructor(private readonly telephoneService: TelephoneService) {}

  public ngOnInit(): void {
    this.getTelephoneList();
  }

  public getTelephoneList(): void {
    this.telephoneService
      .getTelephoneList(true)
      .subscribe((data: ITelephoneListModel[]) => {
        this.telephones = data.map((x) => new TelephoneListModel(x));
        this.dataSource = new MatTableDataSource<ITelephoneListModel>(
          this.telephones
        );
      });
  }

  public deleteTelephone(id: number): void {
    this.telephoneService.delete(id).subscribe(() => this.getTelephoneList());
  }
}
