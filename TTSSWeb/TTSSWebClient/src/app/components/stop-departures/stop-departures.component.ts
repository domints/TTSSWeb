import { Component, HostListener, OnInit } from '@angular/core';
import { StopsService, StopAutocomplete, PassageListItem } from 'src/app/services/stops.service';
import { UntypedFormControl } from '@angular/forms';
import { MatLegacyDialog as MatDialog } from '@angular/material/legacy-dialog';
import { SavePassageDialogComponent } from '../save-passage-dialog/save-passage-dialog.component';
import { IRoutableComponent } from 'src/app/interfaces/IRoutableComponent';
import { DepartureDataService } from 'src/app/services/store-services/departure-data.service';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs/internal/Subscription';
import { PlausibleService } from 'src/app/services/plausible.service';
import { interval } from 'rxjs';


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
  autocompleteControl: UntypedFormControl = new UntypedFormControl();
  autocompleteOptions: StopAutocomplete[] = [];
  currentStop: StopAutocomplete;
  passages: PassageListItem[] = [];
  currentPassages: PassageListItem[] = [];
  oldPassages: PassageListItem[] = [];
  selectedPassage: PassageListItem = null;

  tripId: string;
  isBus: string;

  screenWidth: number;

  refresherSubscription: Subscription;

  constructor(private stopsService: StopsService,
    private dialog: MatDialog,
    private departureDataService: DepartureDataService,
    private router: Router,
    private plausibleService: PlausibleService
  ) { }

  ngOnInit() {
    this.screenWidth = window.innerWidth;
    this.autocompleteControl.valueChanges.subscribe((v: string | StopAutocomplete) => {
      if (!this.stopValueEvents) {
        if (typeof v === "string")
          this.stopsService.getAutocomplete(v).subscribe(r => this.autocompleteOptions = r);
        else
        {
          this.plausibleService.trackEvent("getDepartures", { props: { name: v.name, id: v.groupId}})
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
    this.stopsService.getPassages(this.currentStop.groupId).subscribe(r => {
      this.passages = r;
      this.currentPassages = r.filter(p => !p.isOld);
      this.oldPassages = r.filter(p => p.isOld);
    });
  }

  autocompleteStopDisplayFn(stop?: StopAutocomplete) {
    return stop ? stop.name : undefined;
  }

  passageDetails(item: PassageListItem)
  {
    this.plausibleService.trackEvent("viewPassageDetails");

    if (this.screenWidth < 1200)
      this.router.navigate(['passage', item.tripId, item.isBus]);
    else
    {
      this.selectedPassage = item;
      this.tripId = item.tripId;
      this.isBus = item.isBus;
    }
  }

  @HostListener('window:resize', ['$event'])
  onWindowResize() {
    this.screenWidth = window.innerWidth;
  }
}
