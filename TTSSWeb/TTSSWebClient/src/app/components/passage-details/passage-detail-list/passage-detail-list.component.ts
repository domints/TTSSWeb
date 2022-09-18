import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges } from '@angular/core';
import { interval, Subscription } from 'rxjs';
import { TripPassages, TripPassagesService } from 'src/app/services/trip-passages.service';

@Component({
  selector: 'passage-detail-list',
  templateUrl: './passage-detail-list.component.html',
  styleUrls: ['./passage-detail-list.component.scss']
})
export class PassageDetailListComponent implements OnInit {
  @Output() updateToolbarTitle = new EventEmitter<string>();
  @Input() tripId: string;
  @Input() isBus: string;
  @Input() stopAutoReload: boolean;


  passages: TripPassages;
  edgeIndex: number;
  hasStopping: boolean = false;
  timer: any;
  reloading: boolean = false;
  
  refreshSubscription: Subscription;
  dataLoadSubcsciption: Subscription;

  constructor(
    private tripPassagesService: TripPassagesService) { }

  ngOnInit(): void {
    this.refreshSubscription = interval(5000).subscribe((i) => {
      this.reload();
    });
  }

  ngOnDestroy(): void {
    this.refreshSubscription.unsubscribe();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['tripId'])
      this.reload(true);
  }

  reload(forceReload: boolean = false): void {
    if (this.stopAutoReload)
      return;
    
    if (forceReload)
    {
      this.reloading = false;
      if(this.dataLoadSubcsciption)
        this.dataLoadSubcsciption.unsubscribe();
    }
    
    if (!this.reloading && this.tripId) {
      this.reloading = true;
      this.dataLoadSubcsciption = this.tripPassagesService.getTripPassages(this.tripId, this.isBus).subscribe(psgs => {
        this.reloading = false;
        this.refreshData(psgs);
      });
    }
  }

  refreshData(p: TripPassages) {
    this.passages = p;
    if (this.passages) {
      //this.updateToolbarTitle.emit(this.passages.line + " -> " + this.passages.direction);
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
