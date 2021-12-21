import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Episode } from '../viewmodels/episode.class';
import { Observable } from 'rxjs';
import { IEpisode } from '../interfaces/episode.interface';

@Injectable()
export class EpisodeService {
  public url: string = '/api/episode';

  constructor(private http: HttpClient) {}

  public getEpisodeListWithInclude(): Observable<IEpisode[]> {
    return this.http.get<IEpisode[]>(this.url);
  }

  public getEpisodeWithInclude(id: number): Observable<IEpisode> {
    return this.http.get<IEpisode>(this.url + '/' + id);
  }

  public createEpisode(episode: Episode): Observable<void> {
    return this.http.post<void>(this.url, episode);
  }

  public updateEpisode(episode: Episode): Observable<void> {
    return this.http.put<void>(this.url, episode);
  }

  public deleteEpisode(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
