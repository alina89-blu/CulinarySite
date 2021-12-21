import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ICulinaryChannel } from '../interfaces/culinary-channel.interface';
import { CulinaryChannel } from '../viewmodels/culinary-channel.class';

@Injectable()
export class CulinaryChannelService {
  public url: string = '/api/culinarychannel';

  constructor(private http: HttpClient) {}

  public getCulinaryChannelListWithInclude(): Observable<ICulinaryChannel[]> {
    return this.http.get<ICulinaryChannel[]>(this.url);
  }

  public getCulinaryChannelWithInclude(
    id: number
  ): Observable<ICulinaryChannel> {
    return this.http.get<ICulinaryChannel>(this.url + '/' + id);
  }

  public createCulinaryChannel(
    culinaryChannel: CulinaryChannel
  ): Observable<void> {
    return this.http.post<void>(this.url, culinaryChannel);
  }

  public updateCulinaryChannel(
    culinaryChannel: CulinaryChannel
  ): Observable<void> {
    return this.http.put<void>(this.url, culinaryChannel);
  }

  public deleteCulinaryChannel(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
