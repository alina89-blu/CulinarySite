import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ICulinaryChannelListModel } from 'src/app/interfaces/culinary-channel/culinary-channel-list-model.interface';
import { IEpisodeDetailModel } from 'src/app/interfaces/episode/episode-detail-model.interface';
import { CulinaryChannelService } from 'src/app/services/culinary-channel.service';
import { EpisodeService } from 'src/app/services/episode.service';
import { CulinaryChannelListModel } from 'src/app/viewmodels/culinary-channel/culinary-channel-list-model.class';
import { UpdateEpisodeModel } from 'src/app/viewmodels/episode/update-episode-model.class';

@Component({
  selector: 'app-episode-edit',
  templateUrl: './episode-edit.component.html',
  styleUrls: ['./episode-edit.component.css'],
})
export class EpisodeEditComponent implements OnInit {
  private id: number;
  public updateEpisodeModel: UpdateEpisodeModel = new UpdateEpisodeModel();
  public culinaryChannels: CulinaryChannelListModel[] = [];
  public episodeForm: FormGroup;

  constructor(
    private activeRoute: ActivatedRoute,
    private episodeService: EpisodeService,
    private culinaryChannelService: CulinaryChannelService,
    private router: Router,
    private fb: FormBuilder
  ) {
    this.id = Number.parseInt(this.activeRoute.snapshot.params['id']);

    this.episodeForm = this.fb.group({
      name: ['', Validators.required],
      imageUrl: ['', Validators.required],
      videoUrl: ['', Validators.required],
      culinaryChannelId: ['', Validators.required],
    });
  }

  public ngOnInit(): void {
    if (this.id) {
      this.episodeService
        .getEpisode(this.id, true)
        .subscribe(
          (data: IEpisodeDetailModel) =>
            (this.updateEpisodeModel = new UpdateEpisodeModel(data))
        );
    }
    this.getCulinaryChannelList();
  }

  public getCulinaryChannelList(): void {
    this.culinaryChannelService
      .getCulinaryChannelList(false)
      .subscribe(
        (data: ICulinaryChannelListModel[]) =>
          (this.culinaryChannels = data.map(
            (x) => new CulinaryChannelListModel(x)
          ))
      );
  }

  public updateEpisode(): void {
    this.episodeService
      .updateEpisode(this.updateEpisodeModel)
      .subscribe(() => this.router.navigateByUrl('episode'));
  }
}
