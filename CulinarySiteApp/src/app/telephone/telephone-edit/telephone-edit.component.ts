import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { IRestaurantModel } from 'src/app/interfaces/restaurant/restaurant-model.interface';
import { ITelephoneDetailModel } from 'src/app/interfaces/telephone/telephone-detail-model.interface';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { TelephoneService } from 'src/app/services/telephone.service';
import { RestaurantModel } from 'src/app/viewmodels/restaurant/restaurant-model.class';
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
  public restaurants: RestaurantModel[] = [];
  public telephoneForm: FormGroup;

  constructor(
    private telephoneService: TelephoneService,
    private restaurantService: RestaurantService,
    private router: Router,
    activeRoute: ActivatedRoute,
    private fb: FormBuilder
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);

    this.telephoneForm = this.fb.group({
      number: ['', Validators.required],
      restaurantId: ['', Validators.required],
    });
  }

  public ngOnInit(): void {
    if (this.id) {
      this.telephoneService
        .getTelephone(this.id, true)
        .subscribe(
          (data: ITelephoneDetailModel) =>
            (this.updateTelephoneModel = new UpdateTelephoneModel(data))
        );
    }
    this.getRestaurantList();
  }

  public getRestaurantList(): void {
    this.restaurantService
      .getRestaurantList()
      .subscribe(
        (data: IRestaurantModel[]) =>
          (this.restaurants = data.map((x) => new RestaurantModel(x)))
      );
  }

  public updateTelephone(): void {
    this.telephoneService
      .updateTelephone(this.updateTelephoneModel)
      .subscribe(() => this.router.navigateByUrl('telephone'));
  }
}
