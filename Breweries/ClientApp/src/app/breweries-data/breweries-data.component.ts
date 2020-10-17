import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-breweries-data',
  templateUrl: './breweries-data.component.html',
  styleUrls: ['./breweries-data.component.css']
})
export class BreweriesDataComponent {
  breweries: Brewery[];
  page = 1;
  pageSize = 10;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Brewery[]>(baseUrl + 'api/Breweries?count=100').subscribe(result => {
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
