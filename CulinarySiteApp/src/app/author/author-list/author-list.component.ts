import { Component, OnInit } from '@angular/core';
import { AuthorService } from 'src/app/services/author.service';
import { AuthorListModel } from 'src/app/viewmodels/author/author-list-model.class';
import { IAuthorListModel } from 'src/app/interfaces/author/author-list-model.interface';

@Component({
  selector: 'app-author-list',
  templateUrl: './author-list.component.html',
  styleUrls: ['./author-list.component.css'],
})
export class AuthorListComponent implements OnInit {
  authors: AuthorListModel[] = [];

  constructor(private authorService: AuthorService) {}

  public ngOnInit(): void {
    this.getAuthorList();
  }

  public getAuthorList(): void {
    this.authorService
      .getAuthorDetailList(true)
      .subscribe(
        (data: IAuthorListModel[]) =>
          (this.authors = data.map((x) => new AuthorListModel(x)))
      );
  }

  public deleteAuthor(id: number): void {
    this.authorService.deleteAuthor(id).subscribe(() => this.getAuthorList());
  }
}
