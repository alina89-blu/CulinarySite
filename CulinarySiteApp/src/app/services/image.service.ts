import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

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

  // public getDishImageList(
  //   withRelated: boolean
  // ): Observable<IDishImageListModel[]> {
  //   return this.http.get<IDishImageListModel[]>(
  //     this.url + '/' + withRelated + '/' + 'dish'
  //   );
  // }

  // public getDishImage(
  //   id: number,
  //   withRelated: boolean
  // ): Observable<IDishDetailModel> {
  //   return this.http.get<IDishDetailModel>(
  //     this.url + '/' + id + '/' + withRelated + '/' + 'dish'
  //   );
  // }

  // public createDishImage(
  //   createDishImageModel: CreateDishImageModel
  // ): Observable<void> {
  //   return this.http.post<void>(this.url + '/' + 'dish', createDishImageModel);
  // }

  // public updateDishImage(
  //   updateDishImageModel: UpdateDishImageModel
  // ): Observable<void> {
  //   return this.http.put<void>(this.url + '/' + 'dish', updateDishImageModel);
  // }

  // public getEpisodeImageList(
  //   withRelated: boolean
  // ): Observable<IEpisodeImageListModel[]> {
  //   return this.http.get<IEpisodeImageListModel[]>(
  //     this.url + '/' + withRelated + '/' + 'episode'
  //   );
  // }

  // public getEpisodeImage(
  //   id: number,
  //   withRelated: number
  // ): Observable<IEpisodeDetailModel> {
  //   return this.http.get<IEpisodeDetailModel>(
  //     this.url + '/' + id + '/' + withRelated + '/' + 'episode'
  //   );
  // }

  // public createEpisodeImage(
  //   createEpisodeImageModel: CreateEpisodeImageModel
  // ): Observable<void> {
  //   return this.http.post<void>(
  //     this.url + '/' + 'episode',
  //     createEpisodeImageModel
  //   );
  // }

  // public updateEpisodeImage(
  //   updateEpisodeImageModel: UpdateEpisodeImageModel
  // ): Observable<void> {
  //   return this.http.put<void>(
  //     this.url + '/' + 'episode',
  //     updateEpisodeImageModel
  //   );
  // }

  // public deleteImage(id: number): Observable<void> {
  //   return this.http.delete<void>(this.url + '/' + id);
  // }

  // public getRecipeImageList(
  //   withRelated: boolean
  // ): Observable<IRecipeImageListModel[]> {
  //   return this.http.get<IRecipeImageListModel[]>(
  //     this.url + '/' + withRelated + '/' + 'recipe'
  //   );
  // }

  // public getRecipeImage(
  //   id: number,
  //   withRelated: number
  // ): Observable<IRecipeDetailModel> {
  //   return this.http.get<IRecipeDetailModel>(
  //     this.url + '/' + id + '/' + withRelated + '/' + 'recipe'
  //   );
  // }

  // public createRecipeImage(
  //   createRecipeImageModel: CreateRecipeImageModel
  // ): Observable<void> {
  //   return this.http.post<void>(
  //     this.url + '/' + 'recipe',
  //     createRecipeImageModel
  //   );
  // }

  // public updateRecipeImage(
  //   updateRecipeImageModel: UpdateRecipeImageModel
  // ): Observable<void> {
  //   return this.http.put<void>(
  //     this.url + '/' + 'recipe',
  //     updateRecipeImageModel
  //   );
  // }
}
