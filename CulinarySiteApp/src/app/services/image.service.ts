import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IImage } from '../interfaces/image.interface';
import { Observable } from 'rxjs';
import { Image } from '../viewmodels/image.class';

@Injectable()
export class ImageService {
  public url: string = '/api/image';

  constructor(private http: HttpClient) {}

  public getImageList(): Observable<IImage[]> {
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
  }
}
