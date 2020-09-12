import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { DevicesListComponent } from '../devices-list/devices-list.component';
import { UploadComponent } from '../upload/upload.component';
import { Device } from '../models/Device';

@Component({
  selector: 'app-main',
  templateUrl: './main.component.html',
  styleUrls: ['./main.component.css']
})
export class MainComponent implements OnInit, AfterViewInit {

  @ViewChild(UploadComponent, {static: true}) uploadComponent: UploadComponent;
  @ViewChild(DevicesListComponent, { static: true }) devicesList: DevicesListComponent;

  constructor() { }

  ngAfterViewInit(): void {
  }

  ngOnInit() {
  }

  uploadSucceeded(devices: Device[]) {

    devices.forEach(device => this.devicesList.devices.push(device));

  }

  uploadFailed(obj: object) {
    alert(obj["error"]);
  }

}
