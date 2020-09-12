import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { Device } from "../models/Device";

@Injectable({ providedIn: 'root' })
export class DevicesService {

  constructor(private httpClient: HttpClient) {

  }

  getAllDevices(): Observable<Device[]> {

    return this.httpClient.get<Device[]>("/devices");

  }

  getDeviceById(id: Number): Observable<Device> {

    return this.httpClient.get<Device>("/devices/" + id.toString());

  }

  deleteDevice(device: Device): Observable<any> {

    return this.httpClient.delete<any>("/devices/" + device.entry_Id.toString());

  }

}
