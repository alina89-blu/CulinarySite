import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ICookingStage } from '../interfaces/cooking-stage.interface';
import { CookingStage } from '../viewmodels/cooking-stage.class';

@Injectable()
export class CookingStageService {
  public url: string = '/api/cookingstage';

  constructor(private http: HttpClient) {}

  public getCookingStageListWithInclude(): Observable<ICookingStage[]> {
    return this.http.get<ICookingStage[]>(this.url);
  }

  public getCookingStageWithInclude(id: number): Observable<ICookingStage> {
    return this.http.get<ICookingStage>(this.url + '/' + id);
  }

  public createCookingStage(cookingStage: CookingStage): Observable<void> {
    return this.http.post<void>(this.url, cookingStage);
  }

  public updateCookingStage(cookingStage: CookingStage): Observable<void> {
    return this.http.put<void>(this.url, cookingStage);
  }

  public deleteCookingStage(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
