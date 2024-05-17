import { Component } from '@angular/core';
import { SearchHistory } from '../shared/model/SearchHistory.model';
import { HistoryService } from './../shared/service/history.service';

@Component({
  selector: 'app-history',
  templateUrl: './history.component.html'
})
export class HistoryComponent {
  histories!: SearchHistory[];

  constructor(private historyService: HistoryService) {
  }

  ngOnInit() {
    console.log('hhhh');
    this.historyService.loadHistory().subscribe({
      next: (data) => {
        this.histories = data;
      }
    });
  }
}
