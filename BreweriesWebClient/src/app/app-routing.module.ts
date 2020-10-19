import { NgModule, Component } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './Components/home/home.component';
import { CounterComponent } from './Components/counter/counter.component';
import { FetchDataComponent } from './Components/fetch-data/fetch-data.component';
import { BreweriesDataComponent } from './Components/breweries-data/breweries-data.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'counter', component: CounterComponent },
  { path: 'fetch-data', component: FetchDataComponent },
  { path: 'brewery-data', component: BreweriesDataComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
