import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class StopsService {

  constructor(private http: HttpClient) { }

  public getAutocomplete(value: string): Observable<StopAutocomplete[]> {
    return this.http.get<StopAutocomplete[]>('http://localhost:5163/autocomplete?', { params: { query: value } });
  }

  public getStops(): Observable<Stop[]> {
    return this.http.get<Stop[]>('http://localhost:5163/stops');
  }

  public getPassages(stopId: string): Observable<PassageListItem[]> {
    return this.http.get<PassageListItem[]>('/api/stops/passages', { params: { stopId: stopId } })
  }
}

export enum VehicleType {
  None = 0,
  Tram = 1,
  Bus = 2
}

export class StopAutocomplete {
  groupId: string;
  name: string;
  type: VehicleType;
}

export class PassageListItem {
  line: string;
  direction: string;
  modelName: string;
  sideNo: string;
  floorType: number;
  mixedTime: string;
  vehicleId: string;
  isOld: boolean;
  delayMinutes: number;
  tripId: string;
  isBus: string;
}

export class Stop {
  groupId: string;
  gtfsId: string;
  name: string;
  latitude: number;
  longitude: number;
  type: VehicleType;
}
