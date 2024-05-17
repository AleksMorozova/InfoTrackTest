import { NgModule } from '@angular/core';
import { TabViewModule } from 'primeng/tabview';
import { TableModule } from 'primeng/table';
import { CommonModule } from '@angular/common';
import { ButtonModule } from 'primeng/button';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from './../shared/shared.module';
import { HistoryComponent } from './history.component';
import { HistoryRoutingModule } from './history-routing.module';

@NgModule({
  declarations: [
    HistoryComponent
  ],
  imports: [
    HistoryRoutingModule,
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
    HistoryComponent
  ]
})
export class HistoryModule { }
