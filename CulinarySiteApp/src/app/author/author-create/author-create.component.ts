import { Component, OnInit } from '@angular/core';
import { AuthorService } from 'src/app/services/author.service';
import { Router } from '@angular/router';
import { CreateAuthorModel } from 'src/app/viewmodels/author/create-author-model.class';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-author-create',
  templateUrl: './author-create.component.html',
  styleUrls: ['./author-create.component.css'],
})
export class AuthorCreateComponent implements OnInit {
  public createAuthorModel: CreateAuthorModel = new CreateAuthorModel();
  public authorForm: FormGroup;

  constructor(
    private readonly authorService: AuthorService,
    private readonly router: Router,
    private readonly fb: FormBuilder
  ) {}

  public ngOnInit(): void {
    this.authorForm = this.fb.group({
      name: ['', Validators.required],
    });
  }

  public createAuthor(): void {
    this.authorService
      .createAuthor(this.createAuthorModel)
      .subscribe(() => this.router.navigateByUrl('author'));
  }
}
