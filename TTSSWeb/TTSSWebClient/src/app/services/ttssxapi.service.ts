import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { PassageListItem } from './stops.service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TTSSXApiService {

  constructor(private http: HttpClient) { }

  public savePassage(item: PassageListItem, tramNo: string): Observable<{}> {
    let model = new PassageSaveModel();
    model.line = item.line;
    model.vehicleId = item.vehicleId;
    model.tramNo = tramNo;
    model.dir = item.direction;
    return this.http.post<{}>('https://ttssx.dszymanski.pl/api/app', model);
  }
}

export class PassageSaveModel {
  theirId: string;
  /**
   * line number
   */
  line: string;
  /**
   * TTSS vehicle id
   */
  vehicleId: string;
  /**
   * tram side number
   */
  tramNo: string;
  /**
   * final stop of this journey
   */
  dir: string;
}
