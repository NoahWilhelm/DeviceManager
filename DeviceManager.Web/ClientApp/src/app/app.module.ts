import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { MainComponent } from './main/main.component';
import { UploadComponent } from './upload/upload.component';
import { DevicesListComponent } from './devices-list/devices-list.component';

import { FontAwesomeModule } from '@fortawesome/angular-fontawesome'
import { DeviceDetailsComponent } from './device-details/device-details.component';

import { OverlayModule } from '@angular/cdk/overlay';
import { TooltipComponent } from './entry-components/TooltipComponent';
import { TooltipDirective } from './directives/TooltipDirective';

@NgModule({
  declarations: [
    AppComponent,
    MainComponent,
    UploadComponent,
    DevicesListComponent,
    DeviceDetailsComponent,
    TooltipComponent,
    TooltipDirective
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    FontAwesomeModule,
    OverlayModule,
    RouterModule.forRoot([
      { path: '', component: MainComponent, pathMatch: 'full' },
      { path: 'device/:id', component: DeviceDetailsComponent }
    ])
  ],
  entryComponents: [
    TooltipComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
