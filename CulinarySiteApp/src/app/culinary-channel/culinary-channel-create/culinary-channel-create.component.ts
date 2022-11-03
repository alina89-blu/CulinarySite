import { Component, OnInit } from '@angular/core';
import { CulinaryChannelService } from 'src/app/services/culinary-channel.service';
import { Router } from '@angular/router';
import { CreateCulinaryChannelModel } from 'src/app/viewmodels/culinary-channel/create-culinary-channel-model.class';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-culinary-channel-create',
  templateUrl: './culinary-channel-create.component.html',
  styleUrls: ['./culinary-channel-create.component.css'],
})
export class CulinaryChannelCreateComponent {
  public createCulinaryChannelModel: CreateCulinaryChannelModel =
    new CreateCulinaryChannelModel();
  public culinaryChannelForm: FormGroup;

  constructor(
    private culinaryChannelService: CulinaryChannelService,
    private router: Router,
    private fb: FormBuilder
  ) {
    this.culinaryChannelForm = this.fb.group({
      name: ['', Validators.required],
      content: ['', Validators.required],
    });
  }

  public createCulinaryChannel(): void {
    this.culinaryChannelService
      .createCulinaryChannel(this.createCulinaryChannelModel)
      .subscribe(() => this.router.navigateByUrl('culinaryChannel'));
  }
}
