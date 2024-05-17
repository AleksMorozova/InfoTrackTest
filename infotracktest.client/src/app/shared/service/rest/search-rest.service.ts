import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { SearchRequest } from '../../model/SearchRequest';

@Injectable({
  providedIn: 'root',
})
export class SearchRESTService {
  constructor(protected http: HttpClient) { }

  search(searchRequest: SearchRequest): Observable<any> {
    return this.http.post(`https://localhost:7297/search/count`, searchRequest);
  }
}
