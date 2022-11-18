import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { IRestaurantModel } from 'src/app/interfaces/restaurant/restaurant-model.interface';
import { RestaurantService } from 'src/app/services/restaurant.service';
import { TelephoneService } from 'src/app/services/telephone.service';
import { RestaurantModel } from 'src/app/viewmodels/restaurant/restaurant-model.class';
import { CreateTelephoneModel } from 'src/app/viewmodels/telephone/create-telephone-model.class';

@Component({
  selector: 'app-telephone-create',
  templateUrl: './telephone-create.component.html',
  styleUrls: ['./telephone-create.component.css'],
})
export class TelephoneCreateComponent implements OnInit {
  public createTelephoneModel: CreateTelephoneModel =
    new CreateTelephoneModel();
  public telephoneForm: FormGroup;
  public restaurants: RestaurantModel[] = [];

  constructor(
    private readonly telephoneService: TelephoneService,
    private readonly restaurantService: RestaurantService,
    private readonly router: Router,
    private readonly fb: FormBuilder
  ) {}

  public ngOnInit(): void {
    this.getRestaurantList();

    this.telephoneForm = this.fb.group({
      number: ['', Validators.required],
      restaurantId: ['', Validators.required],
    });
  }

  public getRestaurantList(): void {
    this.restaurantService
      .getRestaurantList()
      .subscribe(
        (data: IRestaurantModel[]) =>
          (this.restaurants = data.map((x) => new RestaurantModel(x)))
      );
  }

  public createTelephone(): void {
    this.telephoneService
      .createTelephone(this.createTelephoneModel)
      .subscribe(() => this.router.navigateByUrl('telephone'));
  }
}
