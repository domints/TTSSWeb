import { Component, OnInit, ViewChild } from '@angular/core';
import { StopsService, StopAutocomplete, PassageListItem } from 'src/app/services/stops.service';
import { FormControl } from '@angular/forms';
import { startWith, map } from 'rxjs/operators';

@Component({
  selector: 'app-stop-departures',
  templateUrl: './stop-departures.component.html',
  styleUrls: ['./stop-departures.component.scss']
})
export class StopDeparturesComponent implements OnInit {
  autocompleteControl: FormControl = new FormControl();
  autocompleteOptions: StopAutocomplete[] = [];
  passages: PassageListItem[] = [];
  
  constructor(private stopsService: StopsService) { }

  ngOnInit() {
    this.autocompleteControl.valueChanges.subscribe(v => {
      if (typeof v === "string")
        this.stopsService.getAutocomplete(v).subscribe(r => this.autocompleteOptions = r);
      else
        this.stopsService.getPassages(v.id).subscribe(r => this.passages = r);
    });
  }

  autocompleteStopDisplayFn(stop?: StopAutocomplete) {
    return stop ? stop.name : undefined;
  }
}
