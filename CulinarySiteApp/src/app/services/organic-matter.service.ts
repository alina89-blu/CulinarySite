import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { IOrganicMatter } from '../interfaces/organic-matter.interface';
import { OrganicMatter } from '../viewmodels/organic-matter.class';

@Injectable()
export class OrganicMatterService {
  public url: string = '/api/organicmatter';

  constructor(private http: HttpClient) {}

  public getOrganicMatterList(): Observable<IOrganicMatter[]> {
    return this.http.get<IOrganicMatter[]>(this.url);
  }

  public getOrganicMatter(id: number): Observable<IOrganicMatter> {
    return this.http.get<IOrganicMatter>(this.url + '/' + id);
  }

  public createOrganicMatter(organicMatter: OrganicMatter): Observable<void> {
    return this.http.post<void>(this.url, organicMatter);
  }

  public updateOrganicMatter(organicMatter: OrganicMatter): Observable<void> {
    return this.http.put<void>(this.url, organicMatter);
  }

  public delete(id: number): Observable<void> {
    return this.http.delete<void>(this.url + '/' + id);
  }
}
