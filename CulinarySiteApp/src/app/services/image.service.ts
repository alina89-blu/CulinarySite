import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IDishImageListModel } from '../interfaces/image/dish-image/dish-image-list-model.interface';
import { IDishDetailModel } from '../interfaces/dish/dish-detail-model.interface';
import { CreateDishImageModel } from '../viewmodels/image/dish-image/create-dish-image-model.class';
import { UpdateDishImageModel } from '../viewmodels/image/dish-image/update-dish-image-model.class';
import { IEpisodeImageListModel } from '../interfaces/image/episode-image/episode-image-list-model.interface';
import { IEpisodeDetailModel } from '../interfaces/episode/episode-detail-model.interface';
import { CreateEpisodeImageModel } from '../viewmodels/image/episode-image/create-episode-image-model.class';
import { UpdateEpisodeImageModel } from '../viewmodels/image/episode-image/update-episode-image-model.class';

@Injectable()
export class ImageService {
  public url: string = '/api/image';

  constructor(private http: HttpClient) {}

  /*public getImageList(): Observable<IImage[]> {
    return this.http.get<IImage[]>(this.url);
  }

  public getImage(id: number): Observable<IImage> {
    return this.http.get<IImage>(this.url + '/' + id);
  }

  public createImage(image: Image): Observable<void> {
    return this.http.post<void>(this.url, image);
  }

  public updateImage(image: Image): Observable<void> {
    return this.http.put<void>(this.url, image);
  }

  public delete(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }*/

  public getDishImageList(
    withRelated: boolean
  ): Observable<IDishImageListModel[]> {
    return this.http.get<IDishImageListModel[]>(
      this.url + '/' + withRelated + '/' + 'dish'
    );
  }

  public getDishImage(
    id: number,
    withRelated: boolean
  ): Observable<IDishDetailModel> {
    return this.http.get<IDishDetailModel>(
      this.url + '/' + id + '/' + withRelated + '/' + 'dish'
    );
  }

  public createDishImage(
    createDishImageModel: CreateDishImageModel
  ): Observable<void> {
    return this.http.post<void>(this.url + '/' + 'dish', createDishImageModel);
  }

  public updateDishImage(
    updateDishImageModel: UpdateDishImageModel
  ): Observable<void> {
    return this.http.put<void>(this.url + '/' + 'dish', updateDishImageModel);
  }

  public getEpisodeImageList(
    withRelated: boolean
  ): Observable<IEpisodeImageListModel[]> {
    return this.http.get<IEpisodeImageListModel[]>(
      this.url + '/' + withRelated + '/' + 'episode'
    );
  }

  public getEpisodeImage(
    id: number,
    withRelated: number
  ): Observable<IEpisodeDetailModel> {
    return this.http.get<IEpisodeDetailModel>(
      this.url + '/' + id + '/' + withRelated + '/' + 'episode'
    );
  }

  public createEpisodeImage(
    createEpisodeImageModel: CreateEpisodeImageModel
  ): Observable<void> {
    return this.http.post<void>(
      this.url + '/' + 'episode',
      createEpisodeImageModel
    );
  }

  public updateEpisodeImage(
    updateEpisodeImageModel: UpdateEpisodeImageModel
  ): Observable<void> {
    return this.http.put<void>(
      this.url + '/' + 'episode',
      updateEpisodeImageModel
    );
  }

  public deleteImage(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
