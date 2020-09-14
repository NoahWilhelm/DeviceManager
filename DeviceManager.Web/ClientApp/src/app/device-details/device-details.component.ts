import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Device } from '../models/Device';
import { DevicesService } from '../services/DevicesService';

import { faCheck, faTimes, faCoffee, faTrash, faArrowLeft } from '@fortawesome/free-solid-svg-icons';

@Component({
  selector: 'app-device-details',
  templateUrl: './device-details.component.html',
  styleUrls: ['./device-details.component.css']
})
export class DeviceDetailsComponent implements OnInit {

  entryId: number;
  entry: Device;
  
  backIcon = faArrowLeft;
  

  constructor(
    private route: ActivatedRoute,
    private devicesService: DevicesService,
    private router: Router
  ) { }

  ngOnInit() {
    this.getEntryId();
  }

  getEntryId() {
    this.route.params.subscribe(x => {
      this.entryId = x.id;
      this.loadEntry();
    });
  }

  loadEntry() {
    this.devicesService.getDeviceById(this.entryId).subscribe(result => this.entry = result, error => this.router.navigateByUrl(''));
  }

  goBack() {
    this.router.navigateByUrl("");
  }


  getBoolIcon(value: boolean) {

    if (value) {
      return faCheck;
    } else {
      return faTimes;
    }

  }

}
