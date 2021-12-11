import { Component, OnInit } from '@angular/core';
import { AuthorService } from 'src/app/services/author.service';
import { Author } from 'src/app/viewmodels/author.class';
import { Router } from '@angular/router';

@Component({
  selector: 'app-author-create',
  templateUrl: './author-create.component.html',
  styleUrls: ['./author-create.component.css'],
})
export class AuthorCreateComponent {
  public author: Author = new Author();

  constructor(private authorService: AuthorService, private router: Router) {}

  public createAuthor(): void {
    this.authorService
      .createAuthor(this.author)
      .subscribe(() => this.router.navigateByUrl('author'));
  }
}
