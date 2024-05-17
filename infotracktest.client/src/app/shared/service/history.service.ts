import { Injectable } from "@angular/core";
import { HistoryRESTService } from "./rest/history-rest.service";
import { Observable } from "rxjs";

@Injectable()
export class HistoryService {

    constructor(protected historyRESTService: HistoryRESTService) {
  }

  loadHistory(): Observable<any> {
    return this.historyRESTService.loadHistory().pipe(); 
  };
}
