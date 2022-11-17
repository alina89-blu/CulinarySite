import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { IAuthorListModel } from 'src/app/interfaces/author/author-list-model.interface';
import { AuthorService } from 'src/app/services/author.service';
import { AuthorListModel } from 'src/app/viewmodels/author/author-list-model.class';

@Component({
  selector: 'app-author-list',
  templateUrl: './author-list.component.html',
  styleUrls: ['./author-list.component.css'],
})
export class AuthorListComponent implements OnInit {
  authors: AuthorListModel[] = [];
  displayedColumns: string[] = ['id', 'name', 'action'];
  dataSource: MatTableDataSource<IAuthorListModel>;

  constructor(private readonly authorService: AuthorService) {}

  public ngOnInit(): void {
    this.getAuthorList();
  }

  public getAuthorList(): void {
    this.authorService.getAuthorList().subscribe((data: IAuthorListModel[]) => {
      this.authors = data.map((x) => new AuthorListModel(x));
      this.dataSource = new MatTableDataSource<IAuthorListModel>(this.authors);
    });
  }

  public deleteAuthor(id: number): void {
    this.authorService.deleteAuthor(id).subscribe(() => this.getAuthorList());
  }
}
