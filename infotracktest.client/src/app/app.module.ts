import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './menu/menu';
import { NgbModule, NgbNavConfig, NgbNavModule } from '@ng-bootstrap/ng-bootstrap';
import { AboutComponent } from './about-component/about.component';
import { BreadcrumbModule } from 'primeng/breadcrumb';
import { HistoryModule } from './history-component/history.module';
import { HistoryRESTService } from './shared/service/rest/history-rest.service';
import { HistoryService } from './shared/service/history.service';
import { SearchService } from './shared/service/search.services';
import { SearchRESTService } from './shared/service/rest/search-rest.service';
import { SearchModule } from './search-component/search.module';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    AboutComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    NgbModule,
    AppRoutingModule,
    BreadcrumbModule,
    HistoryModule,
    SearchModule
  ],
  providers: [
    { provide: HistoryService, useClass: HistoryRESTService },
    { provide: SearchService, useClass: SearchRESTService }
],
  bootstrap: [AppComponent]
})
export class AppModule { }
