import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EpisodeService } from 'src/app/services/episode.service';
import { CulinaryChannelService } from 'src/app/services/culinary-channel.service';
import { CulinaryChannelListModel } from 'src/app/viewmodels/culinary-channel/culinary-channel-list-model.class';
import { ICulinaryChannelListModel } from 'src/app/interfaces/culinary-channel/culinary-channel-list-model.interface';
import { CreateEpisodeModel } from 'src/app/viewmodels/episode/create-episode-model.class';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-episode-create',
  templateUrl: './episode-create.component.html',
  styleUrls: ['./episode-create.component.css'],
})
export class EpisodeCreateComponent implements OnInit {
  public createEpisodeModel: CreateEpisodeModel = new CreateEpisodeModel();
  public culinaryChannels: CulinaryChannelListModel[] = [];
  public episodeForm: FormGroup;

  constructor(
    private episodeService: EpisodeService,
    private router: Router,
    private culinaryChannelService: CulinaryChannelService,
    private fb: FormBuilder
  ) {
    this.episodeForm = this.fb.group({
      name: ['', Validators.required],
      imageUrl: ['', Validators.required],
      videoUrl: ['', Validators.required],
      culinaryChannelId: ['', Validators.required],
    });
  }

  public ngOnInit(): void {
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

  public createEpisode(): void {
    this.episodeService
      .createEpisode(this.createEpisodeModel)
      .subscribe(() => this.router.navigateByUrl('episode'));
  }
}
