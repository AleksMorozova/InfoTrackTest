import { Component } from '@angular/core';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { SearchRequest } from '../shared/model/SearchRequest';
import { SearchService } from '../shared/service/search.services';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html'
})
export class SearchComponent {

  public search: SearchRequest = new SearchRequest();
  public searchForm!: FormGroup;
  public count!: number;

  constructor(private formBuilder: FormBuilder,
    private router: Router,
    private searchService: SearchService) {
  }

  ngOnInit() {
    this.initForm();
  }

  initForm() {
    this.searchForm = this.formBuilder.group({
      term: [this.search.term],
      url: [this.search.url],
    });
  }

  onSubmit() {

    const searchRequest: SearchRequest = {
      term: this.searchForm.value.searchTerm,
      url: this.searchForm.value.url
    }

    this.searchService.search(searchRequest).subscribe({
      next: (data: number) => {
        this.count = data;
      }
    });
  }
}
