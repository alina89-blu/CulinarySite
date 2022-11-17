import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthorService } from 'src/app/services/author.service';
import { UpdateAuthorModel } from 'src/app/viewmodels/author/update-author-model.class';
import { IAuthorDetailModel } from 'src/app/interfaces/author/author-detail-model.interface';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-author-edit',
  templateUrl: './author-edit.component.html',
  styleUrls: ['./author-edit.component.css'],
})
export class AuthorEditComponent implements OnInit {
  public id: number;
  public updateAuthorModel: UpdateAuthorModel = new UpdateAuthorModel();
  public authorForm: FormGroup;

  constructor(
    private readonly authorService: AuthorService,
    private readonly router: Router,
    private readonly fb: FormBuilder,
    activeRoute: ActivatedRoute
  ) {
    this.id = Number.parseInt(activeRoute.snapshot.params['id']);
  }

  public ngOnInit(): void {
    if (this.id) {
      this.authorService
        .getAuthor(this.id, true)
        .subscribe(
          (data: IAuthorDetailModel) =>
            (this.updateAuthorModel = new UpdateAuthorModel(data))
        );
    }

    this.authorForm = this.fb.group({
      name: ['', Validators.required],
    });
  }

  public updateAuthor(): void {
    this.authorService
      .updateAuthor(this.updateAuthorModel)
      .subscribe(() => this.router.navigateByUrl('author'));
  }
}
