import { Component, OnInit } from '@angular/core';
import { AuthorService } from 'src/app/services/author.service';
import { IAuthor } from 'src/app/interfaces/author.interface';
import { Author } from 'src/app/viewmodels/author.class';

@Component({
  selector: 'app-author-list',
  templateUrl: './author-list.component.html',
  styleUrls: ['./author-list.component.css'],
})
export class AuthorListComponent implements OnInit {
  authors: Author[] = [];

  constructor(private authorService: AuthorService) {}

  public ngOnInit(): void {
    this.getAuthorListWithInclude();
  }

  public getAuthorListWithInclude(): void {
    this.authorService
      .getAuthorListWithInclude()
      .subscribe(
        (data: IAuthor[]) => (this.authors = data.map((x) => new Author(x)))
      );
  }

  public deleteAuthor(id: number): void {
    this.authorService
      .deleteAuthor(id)
      .subscribe(() => this.getAuthorListWithInclude());
  }
}
