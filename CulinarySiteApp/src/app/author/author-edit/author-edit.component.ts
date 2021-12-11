import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthorService } from 'src/app/services/author.service';
import { Author } from 'src/app/viewmodels/author.class';
import { IAuthor } from 'src/app/interfaces/author.interface';

@Component({
  selector: 'app-author-edit',
  templateUrl: './author-edit.component.html',
  styleUrls: ['./author-edit.component.css'],
})
export class AuthorEditComponent implements OnInit {
  public id: number;
  public author: Author = new Author();

  constructor(
    private authorService: AuthorService,
    private router: Router,
    activeRoute: ActivatedRoute
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);
  }

  public ngOnInit(): void {
    if (this.id) {
      this.authorService
        .getAuthorWithInclude(this.id)
        .subscribe((data: IAuthor) => (this.author = new Author(data)));
    }
  }
  public updateAuthor(): void {
    this.authorService
      .updateAuthor(this.author)
      .subscribe(() => this.router.navigateByUrl('author'));
  }
}
