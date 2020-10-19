import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-breweries-data',
  templateUrl: './breweries-data.component.html',
  styleUrls: ['./breweries-data.component.css']
})
export class BreweriesDataComponent {
  private apiPath: string = environment.apiUrl;
  breweries: Brewery[];
  page = 1;
  pageSize = 5;

  constructor(http: HttpClient) {
    http.get<Brewery[]>(this.apiPath + '/api/Breweries?count=1000').subscribe(result => {
      this.breweries = result;
    }, error => console.error(error));
  }
}

interface Brewery {
  id: string;
  name: string;
  breweryTypeId: number;
  breweryType: string;
  street: string;
  cityId: number;
  city: string;
  stateId: number;
  state: string;
  postalCode: string;
  url: string;
}
