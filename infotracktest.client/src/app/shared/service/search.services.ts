import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { SearchRequest } from "../model/SearchRequest";
import { SearchRESTService } from "./rest/search-rest.service";

@Injectable()
export class SearchService {

  constructor(protected searchRESTService: SearchRESTService) {
  }

  search(searchCountRequest: SearchRequest): Observable<any> {
    return this.searchRESTService.search(searchCountRequest).pipe();
  }
}
