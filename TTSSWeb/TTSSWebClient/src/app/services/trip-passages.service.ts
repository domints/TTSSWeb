import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class TripPassagesService {

  constructor(private http: HttpClient) { }

  public getTripPassages(tripId: string, isBus: string): Observable<TripPassages>
  {
    return this.http.get<TripPassages>('/api/trips/passages', { params: { tripId: tripId, bus: isBus } });
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
