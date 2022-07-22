import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthorService } from 'src/app/services/author.service';
import { UpdateAuthorModel } from 'src/app/viewmodels/author/update-author-model.class';
import { IAuthorDetailModel } from 'src/app/interfaces/author/author-detail-model.interface';

@Component({
  selector: 'app-author-edit',
  templateUrl: './author-edit.component.html',
  styleUrls: ['./author-edit.component.css'],
})
export class AuthorEditComponent implements OnInit {
  public id: number;
  public updateAuthorModel: UpdateAuthorModel = new UpdateAuthorModel();

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
        .getAuthor(this.id, true)
        .subscribe(
          (data: IAuthorDetailModel) =>
            (this.updateAuthorModel = new UpdateAuthorModel(data))
        );
    }
  }

  public updateAuthor(): void {
    this.authorService
      .updateAuthor(this.updateAuthorModel)
      .subscribe(() => this.router.navigateByUrl('author'));
  }
}
