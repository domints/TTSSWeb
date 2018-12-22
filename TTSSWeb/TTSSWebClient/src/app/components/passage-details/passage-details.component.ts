import { Component, OnInit } from '@angular/core';
import { IRoutableComponent } from 'src/app/interfaces/IRoutableComponent';

@Component({
  selector: 'passage-details',
  templateUrl: './passage-details.component.html',
  styleUrls: ['./passage-details.component.scss']
})
export class PassageDetailsComponent implements OnInit, IRoutableComponent {
  showBackArrow: boolean = true;
  toolbarTitle: string = "Szczegóły";
  onRouteIn() {
    
  }
  onRouteOut() {
    
  }

  constructor() { }

  ngOnInit() {
  }

}
