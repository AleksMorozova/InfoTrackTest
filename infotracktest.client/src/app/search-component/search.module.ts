import { NgModule } from '@angular/core';
import { TabViewModule } from 'primeng/tabview';
import { TableModule } from 'primeng/table';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { SearchComponent } from './search.component';
import { SearchRoutingModule } from './search-routing.module';

@NgModule({
  declarations: [
    SearchComponent
  ],
  imports: [
    SearchRoutingModule,
    TabViewModule,
    TableModule,
    CommonModule,
    ButtonModule,
    ReactiveFormsModule,
    FormsModule,
    SharedModule,
  ],
  providers: [
  ],
  exports: [
    SearchComponent
  ]
})
export class SearchModule { }
