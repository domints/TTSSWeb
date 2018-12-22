import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule, MatButtonModule, MatSidenavModule, MatIconModule, MatListModule, MatAutocompleteModule, MatInputModule, MatFormFieldModule, MatOptionModule, MatDialogModule, MatMenuModule, MatExpansionModule } from '@angular/material';
import { StopDeparturesComponent } from './components/stop-departures/stop-departures.component';
import { HomeComponent } from './components/home/home.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SavePassageDialogComponent } from './components/save-passage-dialog/save-passage-dialog.component';
import { PassageDetailsComponent } from './components/passage-details/passage-details.component';
import { PassageListItemComponent } from './components/passage-list-item/passage-list-item.component';

@NgModule({
  declarations: [
    AppComponent,
    StopDeparturesComponent,
    HomeComponent,
    NotFoundComponent,
    SavePassageDialogComponent,
    PassageDetailsComponent,
    PassageListItemComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ServiceWorkerModule.register('ngsw-worker.js', { enabled: environment.production }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    LayoutModule,
    NgbModule,
    MatAutocompleteModule,
    MatButtonModule,
    MatDialogModule,
    MatExpansionModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatOptionModule,
    MatSidenavModule,
    MatToolbarModule,
    
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [
    SavePassageDialogComponent
  ]
})
export class AppModule { }
