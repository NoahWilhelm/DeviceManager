import { Component, OnInit, AfterViewInit } from '@angular/core';
import { DevicesService } from '../services/DevicesService';
import { Device } from '../models/Device';

import { faCheck, faTimes, faCoffee, faTrash } from '@fortawesome/free-solid-svg-icons';
import { Router } from '@angular/router';

@Component({
  selector: 'app-devices-list',
  templateUrl: './devices-list.component.html',
  styleUrls: ['./devices-list.component.css']
})
export class DevicesListComponent implements OnInit, AfterViewInit {

  devices: Device[];
  trashIcon = faTrash;

  constructor(
    private devicesService: DevicesService,
    private router: Router
  ) { }

  ngAfterViewInit(): void {
  }

  getIconColorByDevice(device: Device) {
    if (device.failsafe) {
      return 'green';
    } else {
      return 'red';
    }
  }

  getIconClsByDevice(device: Device) {
    if (device.failsafe) {
      return faCheck;
    } else {
      return faTimes;
    }
  }

  ngOnInit() {

    this.loadDevices();

  }

  loadDevices() {

    this.devicesService.getAllDevices().subscribe(result => this.devices = result);

  }

  deleteDevice(device: Device) {
    this.devicesService.deleteDevice(device).subscribe(result => {
      this.loadDevices();
    });
  }

  showDeviceDetails(device: Device) {

    this.router.navigateByUrl("/device/" + device.entry_Id.toString());

  }

}
