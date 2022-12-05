import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ServiceWorkerModule } from '@angular/service-worker';
import { environment } from '../environments/environment';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatLegacyButtonModule as MatButtonModule } from '@angular/material/legacy-button';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatLegacyListModule as MatListModule } from '@angular/material/legacy-list';
import { MatLegacyAutocompleteModule as MatAutocompleteModule } from '@angular/material/legacy-autocomplete';
import { MatLegacyInputModule as MatInputModule } from '@angular/material/legacy-input';
import { MatLegacyFormFieldModule as MatFormFieldModule } from '@angular/material/legacy-form-field';
import { MatLegacySelectModule as MatSelectModule } from '@angular/material/legacy-select';
import { MatLegacyDialogModule as MatDialogModule } from '@angular/material/legacy-dialog';
import { MatLegacyMenuModule as MatMenuModule } from '@angular/material/legacy-menu';
import { MatExpansionModule } from '@angular/material/expansion';
import { StopDeparturesComponent } from './components/stop-departures/stop-departures.component';
import { HomeComponent } from './components/home/home.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SavePassageDialogComponent } from './components/save-passage-dialog/save-passage-dialog.component';
import { PassageDetailsComponent } from './components/passage-details/passage-details.component';
import { PassageDetailListComponent } from './components/passage-details/passage-detail-list/passage-detail-list.component';
import { PassageListItemComponent } from './components/list-items/passage-list-item/passage-list-item.component';
import { TripPassageListItemComponent } from './components/list-items/trip-passage-list-item/trip-passage-list-item.component';
import { MapComponent } from './components/map/map.component';
import { FavouriteStopListItemComponent } from './components/list-items/favourite-stop-list-item/favourite-stop-list-item.component';

@NgModule({
    declarations: [
        AppComponent,
        StopDeparturesComponent,
        HomeComponent,
        NotFoundComponent,
        SavePassageDialogComponent,
        PassageDetailsComponent,
        PassageDetailListComponent,
        PassageListItemComponent,
        TripPassageListItemComponent,
        FavouriteStopListItemComponent,
        MapComponent,
        PassageDetailListComponent
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
        MatSelectModule,
        MatSidenavModule,
        MatToolbarModule,
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
