import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { IRestaurantListModel } from 'src/app/interfaces/restaurant/restaurant-list-model.interface';
import { ITelephoneDetailModel } from 'src/app/interfaces/telephone/telephone-detail-model.interface';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { TelephoneService } from 'src/app/services/telephone.service';
import { RestaurantListModel } from 'src/app/viewmodels/restaurant/restaurant-list-model.class';
import { UpdateTelephoneModel } from 'src/app/viewmodels/telephone/update-telephone-model.class';

@Component({
  selector: 'app-telephone-edit',
  templateUrl: './telephone-edit.component.html',
  styleUrls: ['./telephone-edit.component.css'],
})
export class TelephoneEditComponent implements OnInit {
  private id: number;
  public updateTelephoneModel: UpdateTelephoneModel =
    new UpdateTelephoneModel();
  public restaurants: RestaurantListModel[] = [];

  constructor(
    private telephoneService: TelephoneService,
    private restaurantService: RestaurantService,
    private router: Router,
    activeRoute: ActivatedRoute
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);
  }

  public ngOnInit(): void {
    if (this.id) {
      this.telephoneService
        .getTelephone(this.id)
        .subscribe(
          (data: ITelephoneDetailModel) =>
            (this.updateTelephoneModel = new UpdateTelephoneModel(data))
        );
    }
    this.getRestaurantList();
  }

  public updateTelephone(): void {
    this.telephoneService
      .updateTelephone(this.updateTelephoneModel)
      .subscribe(() => this.router.navigateByUrl('telephone'));
  }

  public getRestaurantList(): void {
    this.restaurantService
      .getRestaurantList(false)
      .subscribe(
        (data: IRestaurantListModel[]) =>
          (this.restaurants = data.map((x) => new RestaurantListModel(x)))
      );
  }
}
