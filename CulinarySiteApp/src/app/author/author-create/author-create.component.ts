import { Component } from '@angular/core';
import { AuthorService } from 'src/app/services/author.service';
import { Router } from '@angular/router';
import { CreateAuthorModel } from 'src/app/viewmodels/author/create-author-model.class';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-author-create',
  templateUrl: './author-create.component.html',
  styleUrls: ['./author-create.component.css'],
})
export class AuthorCreateComponent {
  public createAuthorModel: CreateAuthorModel = new CreateAuthorModel();
  name = new FormControl('', Validators.required);

  constructor(private authorService: AuthorService, private router: Router) {}

  public createAuthor(): void {
    this.authorService
      .createAuthor(this.createAuthorModel)
      .subscribe(() => this.router.navigateByUrl('author'));
  }
}
