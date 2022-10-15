import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IEpisodeDetailModel } from 'src/app/interfaces/episode/episode-detail-model.interface';
import { EpisodeService } from 'src/app/services/episode.service';
import { EpisodeDetailModel } from 'src/app/viewmodels/episode/episode-detail-model.class';

@Component({
  selector: 'app-episode-detail',
  templateUrl: './episode-detail.component.html',
  styleUrls: ['./episode-detail.component.css'],
})
export class EpisodeDetailComponent implements OnInit {
  id: number;
  episodeDetailModel: EpisodeDetailModel = new EpisodeDetailModel();

  constructor(
    private episodeService: EpisodeService,
    activeRoute: ActivatedRoute,
    private http: HttpClient
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);
  }

  public ngOnInit(): void {
    if (this.id) {
      this.episodeService
        .getEpisode(this.id, true)
        .subscribe(
          (data: IEpisodeDetailModel) =>
            (this.episodeDetailModel = new EpisodeDetailModel(data))
        );
    }
  }
}
