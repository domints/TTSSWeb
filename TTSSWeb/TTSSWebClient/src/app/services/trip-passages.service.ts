import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { VehicleType, vehicleTypeToString } from './stops.service';

@Injectable({
  providedIn: 'root'
})
export class TripPassagesService {

  constructor(private http: HttpClient) { }

  public getTripPassages(tripId: string, vehicleType: string): Observable<TripPassages>
  {
    return this.http.get<TripPassages>(`https://gtfs.dszymanski.pl/departures/trip/${tripId}`, { params: { vehicleType: vehicleType } });
  }
}

export class TripPassages {
  line: string;
  direction: string;
  listItems: TripPassageListItem[];
}

export class TripPassageListItem {
  actualTime: string;
  stopId: string;
  stopName: string;
  seqNumber: number;
  isOld: boolean;
  isStopping: boolean;
}
