import { Component, OnInit, OnDestroy } from '@angular/core';
import { IRoutableComponent } from 'src/app/interfaces/IRoutableComponent';
import { ActivatedRoute } from '@angular/router';
import { TripPassages, TripPassagesService } from 'src/app/services/trip-passages.service';
import { interval } from 'rxjs/internal/observable/interval';
import { Subscription } from 'rxjs';

@Component({
  selector: 'passage-details',
  templateUrl: './passage-details.component.html',
  styleUrls: ['./passage-details.component.scss']
})
export class PassageDetailsComponent implements OnInit, OnDestroy, IRoutableComponent {
  showBackArrow: boolean = true;
  toolbarTitle: string = "Szczegóły";
  passages: TripPassages;
  edgeIndex: number;
  hasStopping: boolean = false;
  timer: any;
  tripId: string;
  isBus: string;
  reloading: boolean = false;

  refreshSubscription: Subscription;
  paramSubscription: Subscription;

  onRouteIn() {

  }
  onRouteOut() {

  }

  constructor(
    private route: ActivatedRoute,
    private tripPassagesService: TripPassagesService) { }

  ngOnInit() {
    this.refreshData(this.route.snapshot.data.passages);
    this.tripId = this.route.snapshot.params.id;
    this.isBus = this.route.snapshot.params.isBus;
    this.paramSubscription = this.route.params.subscribe(p => this.tripId = p.id);
    this.refreshSubscription = interval(5000).subscribe((i) => {
      if (!this.reloading && this.tripId) {
        this.reloading = true;
        this.tripPassagesService.getTripPassages(this.tripId, this.isBus).subscribe(psgs => {
          this.reloading = false;
          this.refreshData(psgs);
        });
      }
    });
  }
  ngOnDestroy(): void {
    this.refreshSubscription.unsubscribe();
    this.paramSubscription.unsubscribe();
  }

  refreshData(p: TripPassages) {
    this.passages = p;
    if (this.passages) {
      this.toolbarTitle = this.passages.line + " -> " + this.passages.direction;
    }

    this.hasStopping = this.passages.listItems.some(p => p.isStopping);
    if(this.hasStopping)
    {
      this.edgeIndex = -10;
      return;
    }
    let index = 0;
    for (let p of this.passages.listItems) {
      if (p.isOld == false) {
        this.edgeIndex = index - 1;
        break;
      }

      index++;
    }
  }
}
