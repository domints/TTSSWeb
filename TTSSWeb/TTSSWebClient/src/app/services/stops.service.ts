import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class StopsService {

  constructor(private http: HttpClient) { }

  public getAutocomplete(value: string): Observable<StopAutocomplete[]> {
    return this.http.get<StopAutocomplete[]>('/api/stops/autocomplete?', { params: { q: value } });
  }

  public getPassages(stopId: string): Observable<PassageListItem[]> {
    return this.http.get<PassageListItem[]>('/api/stops/passages', { params: { stopId: stopId } })
  }
}

export class StopAutocomplete {
  id: string;
  name: string;
}

export class PassageListItem {
  line: string;
  direction: string;
  tramDescription: string;
  mixedTime: string;
  vehicleId: string;
  isOld: boolean;
  delayMinutes: number;
  tripId: string;
  isBus: string;
}
