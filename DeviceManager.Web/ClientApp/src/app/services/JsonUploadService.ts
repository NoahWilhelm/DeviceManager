import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpClient } from "@angular/common/http";

@Injectable({ providedIn: 'root' })
export class JsonUploadService {

  constructor(private httpClient: HttpClient) {}

  uploadJsonFile(file: File): Observable<any>{

    const formData: FormData = new FormData();
    formData.append('jsonFile', file, file.name);

    return this.httpClient.post("/jsonFileImport", formData);

  }

}
