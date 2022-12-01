import { Component, OnInit } from '@angular/core';
import { IRoutableComponent } from 'src/app/interfaces/IRoutableComponent';
import Map from 'ol/Map';
import View from 'ol/View';
import TileLayer from 'ol/layer/Tile';
import { OSM } from 'ol/source';
import { fromLonLat, transform } from 'ol/proj';
//import {Circle as CircleStyle, Fill, Stroke, Style} from 'ol/style';
import MapEventType from 'ol/MapEventType';
import { Coordinate } from 'ol/coordinate';
import { MapDataService } from 'src/app/services/store-services/map-data.service';
import { Stop, StopsService, VehicleType } from 'src/app/services/stops.service';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss']
})
export class MapComponent implements OnInit, IRoutableComponent {
  map: Map;
  view: View;


  centerLat: number = 50.0660383;
  centerLon: number = 19.9466524;
  stops: Stop[] = [];

  /*private stopStyles = {
    1: new Style({
      image: new CircleStyle({
        radius: 5,
        fill: new Fill({color: '#5F77F5'}),
        stroke: new Stroke({color: '#3D5CF5', width: 1}),
      }),
    }),
    2: new Style({
      image: new CircleStyle({
        radius: 5,
        fill: new Fill({color: '#F55F76'}),
        stroke: new Stroke({color: '#F53D59', width: 1}),
      }),
    }),
    4: new Style({
      image: new CircleStyle({
        radius: 5,
        fill: new Fill({color: '#5FF57D'}),
        stroke: new Stroke({color: '#3DF562', width: 1}),
      }),
    }),
    8: new Style({
      image: new CircleStyle({
        radius: 5,
        fill: new Fill({color: '#F5CF5F'}),
        stroke: new Stroke({color: '#F5C73D', width: 1}),
      }),
    }),
  };*/

  constructor(private mapDataService: MapDataService, private stopsService: StopsService) { }

  showBackArrow: boolean = true;
  toolbarTitle: string = "Mapa";
  onRouteIn() {
    this.mapDataService.restore(this);
  }
  onRouteOut() {
    this.mapDataService.store(this);
  }

  ngOnInit() {
    if (this.stops.length == 0) {
      this.stopsService.getStops().subscribe(s => this.stops = s);
    }

    this.view = new View({
      center: fromLonLat([this.centerLon, this.centerLat]),
      zoom: 14
    });

    this.map = new Map({
      target: 'map',
      layers: [
        new TileLayer({
          source: new OSM()
        })
      ],
      view: this.view
    });
    (<any>this.map).on(MapEventType.MOVEEND, (e) => {
      let coord = this.getCenterCoord(e.map);
      this.centerLon = coord[0];
      this.centerLat = coord[1];
    });
  }

  getCenterCoord(map: Map): Coordinate {
    let origCenter = map.getView().getCenter();
    return transform(origCenter, 'EPSG:3857', 'EPSG:4326');
  }
}
