import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ICookingStageListModel } from '../interfaces/cooking-stage/cooking-stage-list-model.interface';
import { ICookingStageDetailModel } from '../interfaces/cooking-stage/cooking-stage-detail-model.interface';
import { CreateCookingStageModel } from '../viewmodels/cooking-stage/create-cooking-stage-model.class';
import { UpdateCookingStageModel } from '../viewmodels/cooking-stage/update-cooking-stage-model.class';

@Injectable()
export class CookingStageService {
  public url: string = '/api/cookingstage';

  constructor(private http: HttpClient) {}

  public getCookingStageList(
    withRelated: boolean
  ): Observable<ICookingStageListModel[]> {
    return this.http.get<ICookingStageListModel[]>(
      this.url + '/' + withRelated
    );
  }

  public getCookingStage(
    id: number,
    withRelated: boolean
  ): Observable<ICookingStageDetailModel> {
    return this.http.get<ICookingStageDetailModel>(
      this.url + '/' + id + '/' + withRelated
    );
  }

  public createCookingStage(
    createCookingStageModel: CreateCookingStageModel
  ): Observable<void> {
    return this.http.post<void>(this.url, createCookingStageModel);
  }

  public updateCookingStage(
    updateCookingStageModel: UpdateCookingStageModel
  ): Observable<void> {
    return this.http.put<void>(this.url, updateCookingStageModel);
  }

  public deleteCookingStage(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
