import { Component, OnInit } from '@angular/core';
import { ITelephoneListModel } from 'src/app/interfaces/telephone/telephone-list-model.interface';
import { TelephoneService } from 'src/app/services/telephone.service';
import { TelephoneListModel } from 'src/app/viewmodels/telephone/telephone-list-model.class';

@Component({
  selector: 'app-telephone-list',
  templateUrl: './telephone-list.component.html',
  styleUrls: ['./telephone-list.component.css'],
})
export class TelephoneListComponent implements OnInit {
  telephones: TelephoneListModel[] = [];

  constructor(private telephoneService: TelephoneService) {}

  public ngOnInit(): void {
    this.getTelephoneList();
  }

  public getTelephoneList(): void {
    this.telephoneService
      .getTelephoneList()
      .subscribe(
        (data: ITelephoneListModel[]) =>
          (this.telephones = data.map((x) => new TelephoneListModel(x)))
      );
  }

  public deleteTelephone(id: number): void {
    this.telephoneService.delete(id).subscribe(() => this.getTelephoneList());
  }
}
