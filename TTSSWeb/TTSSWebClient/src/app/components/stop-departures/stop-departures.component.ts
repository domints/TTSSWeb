import { Component, OnInit } from '@angular/core';
import { StopsService, StopAutocomplete, PassageListItem } from 'src/app/services/stops.service';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material';
import { SavePassageDialogComponent } from '../save-passage-dialog/save-passage-dialog.component';
import { IRoutableComponent } from 'src/app/interfaces/IRoutableComponent';
import { DepartureDataService } from 'src/app/services/store-services/departure-data.service';
import { Router } from '@angular/router';
import { interval } from 'rxjs/internal/observable/interval';
import { Subscription } from 'rxjs/internal/Subscription';

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
    if(this.currentStop)
    {
      this.refreshPassages();
      //this.startRefresher();
    }
    this.stopValueEvents = false;
  }
  onRouteOut() {
    this.stopRefresher();
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

  refresherSubscription: Subscription;

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
          this.stopRefresher();
          this.currentStop = v;
          this.refreshPassages();
          //this.startRefresher();
          this.toolbarTitle = "Odjazdy - " + v.name;
        }
      }
    });
  }

  startRefresher() {
    if(!this.refresherSubscription || this.refresherSubscription.closed)
      this.refresherSubscription = interval(20000).subscribe(() => this.refreshPassages());
  }

  stopRefresher() {
    if(this.refresherSubscription && !this.refresherSubscription.closed)
      this.refresherSubscription.unsubscribe();
  }

  refreshPassages()
  {
    this.stopsService.getPassages(this.currentStop.id).subscribe(r => {
      this.passages = r;
      this.currentPassages = r.filter(p => !p.isOld);
      this.oldPassages = r.filter(p => p.isOld);
    });
  }

  autocompleteStopDisplayFn(stop?: StopAutocomplete) {
    return stop ? stop.name : undefined;
  }

  savePassage(item: PassageListItem) {
    this.dialog.open(SavePassageDialogComponent, { data: JSON.parse(JSON.stringify(item)) });
  }

  passageDetails(item: PassageListItem)
  {
    this.router.navigate(['passage', item.tripId, item.isBus ]);
  }
}
