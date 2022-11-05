import { Component, OnInit } from '@angular/core';
import { IEpisodeListModel } from '../interfaces/episode/episode-list-model.interface';
import { EpisodeService } from '../services/episode.service';
import { EpisodeListModel } from '../viewmodels/episode/episode-list-model.class';

@Component({
  selector: 'app-episodes-library',
  templateUrl: './episodes-library.component.html',
  styleUrls: ['./episodes-library.component.css'],
})
export class EpisodesLibraryComponent implements OnInit {
  public episodes: EpisodeListModel[] = [];
  constructor(private episodeService: EpisodeService) {}

  ngOnInit(): void {
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
}
