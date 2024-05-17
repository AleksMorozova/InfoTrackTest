import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MenuComponent } from './menu/menu';
import { AboutComponent } from './about-component/about.component';

const routes: Routes = [
  {
  path: '',
  component: MenuComponent,
    pathMatch: 'full'
  },
  {
    path: 'history',
    loadChildren: () => import('./history-component/history.module').then(m => m.HistoryModule),
    data: { preload: true }
  },
  {
    path: 'search',
    loadChildren: () => import('./search-component/search.module').then(m => m.SearchModule),
    data: { preload: true }
  },
  { path: 'about', component: AboutComponent }];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
