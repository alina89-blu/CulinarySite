import { Component, OnInit } from '@angular/core';
import { CulinaryChannelService } from 'src/app/services/culinary-channel.service';
import { ActivatedRoute, Router } from '@angular/router';
import { UpdateCulinaryChannelModel } from 'src/app/viewmodels/culinary-channel/update-culinary-channel-model.class';
import { ICulinaryChannelDetail } from 'src/app/interfaces/culinary-channel/culinary-channel-detail.interface';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-culinary-channel-edit',
  templateUrl: './culinary-channel-edit.component.html',
  styleUrls: ['./culinary-channel-edit.component.css'],
})
export class CulinaryChannelEditComponent implements OnInit {
  private id: number;
  public updateCulinaryChannelModel: UpdateCulinaryChannelModel =
    new UpdateCulinaryChannelModel();
  public culinaryChannelForm: FormGroup;

  constructor(
    private culinaryChannelService: CulinaryChannelService,
    private router: Router,
    activeRoute: ActivatedRoute,
    private fb: FormBuilder
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);
    this.culinaryChannelForm = this.fb.group({
      name: ['', Validators.required],
      content: ['', Validators.required],
    });
  }

  public ngOnInit(): void {
    if (this.id) {
      this.culinaryChannelService
        .getCulinaryChannel(this.id, false)
        .subscribe(
          (data: ICulinaryChannelDetail) =>
            (this.updateCulinaryChannelModel = new UpdateCulinaryChannelModel(
              data
            ))
        );
    }
  }

  public updateCulinaryChannel(): void {
    this.culinaryChannelService
      .updateCulinaryChannel(this.updateCulinaryChannelModel)
      .subscribe(() => this.router.navigateByUrl('culinaryChannel'));
  }
}
