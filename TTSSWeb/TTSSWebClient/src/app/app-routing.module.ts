import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StopDeparturesComponent } from './components/stop-departures/stop-departures.component';
import { HomeComponent } from './components/home/home.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { PassageDetailsComponent } from './components/passage-details/passage-details.component';
import { TripPassagesResolver } from './resolvers/trip-passages.resolver';
import { MapComponent } from './components/map/map.component';

const routes: Routes = [
  { path: 'departures', component: StopDeparturesComponent },
  { path: 'passage/:id/:isBus', component: PassageDetailsComponent, resolve: { passages: TripPassagesResolver } },
  { path: 'map', component: MapComponent },
  { path: '', component: HomeComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  providers: [TripPassagesResolver]
})
export class AppRoutingModule { }
