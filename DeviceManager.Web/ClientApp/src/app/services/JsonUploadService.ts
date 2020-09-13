import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";
import { Device } from "../models/Device";

@Injectable({ providedIn: 'root' })
export class JsonUploadService {

  constructor(private httpClient: HttpClient) {}

  uploadJsonFile(file: File): Observable<Device[]>{

    const formData: FormData = new FormData();
    formData.append('jsonFile', file, file.name);

    return this.httpClient.post<Device[]>("/api/jsonFileImport", formData);

  }

}
