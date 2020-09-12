import { Component, OnInit, ViewChild, ElementRef, Output, EventEmitter } from '@angular/core';
import { JsonUploadService } from '../services/JsonUploadService';
import { Device } from '../models/Device';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {

  @ViewChild('uploadInput', { static: true })
  uploadInput: ElementRef;

  @Output() onUploadSucceed = new EventEmitter<object>();
  @Output() onUploadFail = new EventEmitter<object>();

  constructor(private jsonUploadService: JsonUploadService) { }

  ngOnInit() {
  }

  startUpload() {

    this.uploadInput.nativeElement.click();

  }

  filesChanged(files: FileList) {

    var firstFile = files[0];

    this.jsonUploadService.uploadJsonFile(firstFile)
      .subscribe(
        (response) => {
          this.onUploadSucceed.emit(response);
        },
        (error) => {
          this.onUploadFail.emit(error);
        }
      );

  }

}
