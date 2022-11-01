import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { ICulinaryChannelListModel } from 'src/app/interfaces/culinary-channel/culinary-channel-list-model.interface';
import { CulinaryChannelService } from 'src/app/services/culinary-channel.service';
import { CulinaryChannelListModel } from 'src/app/viewmodels/culinary-channel/culinary-channel-list-model.class';

@Component({
  selector: 'app-culinary-channel-list',
  templateUrl: './culinary-channel-list.component.html',
  styleUrls: ['./culinary-channel-list.component.css'],
})
export class CulinaryChannelListComponent implements OnInit {
  public culinaryChannels: CulinaryChannelListModel[] = [];
  displayedColumns: string[] = ['id', 'name', 'content', 'action'];
  dataSource: MatTableDataSource<ICulinaryChannelListModel>;

  constructor(private culinaryChannelService: CulinaryChannelService) {}

  public ngOnInit(): void {
    this.getCulinaryChannelList();
  }

  public getCulinaryChannelList(): void {
    this.culinaryChannelService
      .getCulinaryChannelList(false)
      .subscribe((data: ICulinaryChannelListModel[]) => {
        this.culinaryChannels = data.map(
          (x) => new CulinaryChannelListModel(x)
        );
        this.dataSource = new MatTableDataSource<ICulinaryChannelListModel>(
          this.culinaryChannels
        );
      });
  }

  public deleteCulinaryChannel(id: number) {
    this.culinaryChannelService
      .deleteCulinaryChannel(id)
      .subscribe(() => this.getCulinaryChannelList());
  }
}
