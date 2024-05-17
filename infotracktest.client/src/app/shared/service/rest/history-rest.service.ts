import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class HistoryRESTService {
    constructor(protected http: HttpClient) { }

  loadHistory(): Observable<any> {
    console.log('2');

        return this.http.get('https://localhost:7297/search/history')
    };
}
