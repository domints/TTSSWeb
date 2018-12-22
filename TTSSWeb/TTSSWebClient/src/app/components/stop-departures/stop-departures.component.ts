import { Component, OnInit } from '@angular/core';
import { StopsService, StopAutocomplete, PassageListItem } from 'src/app/services/stops.service';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material';
import { SavePassageDialogComponent } from '../save-passage-dialog/save-passage-dialog.component';
import { IRoutableComponent } from 'src/app/interfaces/IRoutableComponent';
import { DepartureDataService } from 'src/app/services/departure-data.service';
import { Router } from '@angular/router';

@Component({
  selector: 'stop-departures',
  templateUrl: './stop-departures.component.html',
  styleUrls: ['./stop-departures.component.scss']
})
export class StopDeparturesComponent implements OnInit, IRoutableComponent {
  stopValueEvents: boolean = false;
  onRouteIn() {
    this.stopValueEvents = true;
    this.departureDataService.restore(this);
    this.stopValueEvents = false;
  }
  onRouteOut() {
    this.departureDataService.store(this);
  }
  showBackArrow: boolean = false;
  toolbarTitle: string = "Odjazdy";
  autocompleteControl: FormControl = new FormControl();
  autocompleteOptions: StopAutocomplete[] = [];
  currentStop: StopAutocomplete;
  passages: PassageListItem[] = [];
  currentPassages: PassageListItem[] = [];
  oldPassages: PassageListItem[] = [];

  constructor(private stopsService: StopsService,
    private dialog: MatDialog,
    private departureDataService: DepartureDataService,
    private router: Router) { }

  ngOnInit() {
    this.autocompleteControl.valueChanges.subscribe(v => {
      if (!this.stopValueEvents) {
        if (typeof v === "string")
          this.stopsService.getAutocomplete(v).subscribe(r => this.autocompleteOptions = r);
        else
        {
          this.currentStop = v;
          this.stopsService.getPassages(v.id).subscribe(r => {
            this.passages = r;
            this.currentPassages = r.filter(p => !p.isOld);
            this.oldPassages = r.filter(p => p.isOld);
          });
          this.toolbarTitle = "Odjazdy - " + v.name;
        }
      }
    });
  }

  autocompleteStopDisplayFn(stop?: StopAutocomplete) {
    return stop ? stop.name : undefined;
  }

  savePassage(item: PassageListItem) {
    this.dialog.open(SavePassageDialogComponent, { data: item });
  }

  passageDetails(item: PassageListItem)
  {
    this.router.navigate(['passage', { id: item.tripId }]);
  }
}
