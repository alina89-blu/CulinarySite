import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IEpisodeListModel } from '../interfaces/episode/episode-list-model.interface';
import { IEpisodeDetailModel } from '../interfaces/episode/episode-detail-model.interface';
import { CreateEpisodeModel } from '../viewmodels/episode/create-episode-model.class';
import { UpdateEpisodeModel } from '../viewmodels/episode/update-episode-model.class';

@Injectable()
export class EpisodeService {
  public url: string = '/api/episode';

  constructor(private http: HttpClient) {}

  public getEpisodeList(withRelated: boolean): Observable<IEpisodeListModel[]> {
    return this.http.get<IEpisodeListModel[]>(this.url + '/' + withRelated);
  }

  public getEpisode(
    id: number,
    withRelated: boolean
  ): Observable<IEpisodeDetailModel> {
    return this.http.get<IEpisodeDetailModel>(
      this.url + '/' + id + '/' + withRelated
    );
  }

  public createEpisode(
    createEpisodeModel: CreateEpisodeModel
  ): Observable<void> {
    return this.http.post<void>(this.url, createEpisodeModel);
  }

  public updateEpisode(
    updateEpisodeModel: UpdateEpisodeModel
  ): Observable<void> {
    return this.http.put<void>(this.url, updateEpisodeModel);
  }

  public deleteEpisode(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
