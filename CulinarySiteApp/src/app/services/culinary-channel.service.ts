import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ICulinaryChannelListModel } from '../interfaces/culinary-channel/culinary-channel-list-model.interface';
import { ICulinaryChannelDetail } from '../interfaces/culinary-channel/culinary-channel-detail.interface';
import { CreateCulinaryChannelModel } from '../viewmodels/culinary-channel/create-culinary-channel-model.class';
import { UpdateCulinaryChannelModel } from '../viewmodels/culinary-channel/update-culinary-channel-model.class';
import { ICulinaryChannelModel } from '../interfaces/culinary-channel/culinary-channel.interface';

@Injectable()
export class CulinaryChannelService {
  public url: string = '/api/culinarychannel';

  constructor(private http: HttpClient) {}

  public getCulinaryChannelDetailList(
    withRelated: boolean
  ): Observable<ICulinaryChannelListModel[]> {
    return this.http.get<ICulinaryChannelListModel[]>(
      this.url + '/' + withRelated
    );
  }

  public getCulinaryChannelList(): Observable<ICulinaryChannelModel[]> {
    return this.http.get<ICulinaryChannelModel[]>(this.url);
  }

  public getCulinaryChannel(
    id: number,
    withRelated: boolean
  ): Observable<ICulinaryChannelDetail> {
    return this.http.get<ICulinaryChannelDetail>(
      this.url + '/' + id + '/' + withRelated
    );
  }

  public createCulinaryChannel(
    createCulinaryChannelModel: CreateCulinaryChannelModel
  ): Observable<void> {
    return this.http.post<void>(this.url, createCulinaryChannelModel);
  }

  public updateCulinaryChannel(
    updateCulinaryChannelModel: UpdateCulinaryChannelModel
  ): Observable<void> {
    return this.http.put<void>(this.url, updateCulinaryChannelModel);
  }

  public deleteCulinaryChannel(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
