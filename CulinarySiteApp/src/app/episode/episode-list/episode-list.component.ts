import { Component, OnInit } from '@angular/core';
import { IEpisodeListModel } from 'src/app/interfaces/episode/episode-list-model.interface';
import { EpisodeService } from 'src/app/services/episode.service';
import { EpisodeListModel } from 'src/app/viewmodels/episode/episode-list-model.class';

@Component({
  selector: 'app-episode-list',
  templateUrl: './episode-list.component.html',
  styleUrls: ['./episode-list.component.css'],
})
export class EpisodeListComponent implements OnInit {
  public episodes: EpisodeListModel[] = [];

  constructor(private episodeService: EpisodeService) {}

  public ngOnInit(): void {
    this.getEpisodeList();
  }

  public getEpisodeList(): void {
    this.episodeService
      .getEpisodeList(true)
      .subscribe(
        (data: IEpisodeListModel[]) =>
          (this.episodes = data.map((x) => new EpisodeListModel(x)))
      );
  }

  public deleteEpisode(id: number): void {
    this.episodeService
      .deleteEpisode(id)
      .subscribe(() => this.getEpisodeList());
  }
}
