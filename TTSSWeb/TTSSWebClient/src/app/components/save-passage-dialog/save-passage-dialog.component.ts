import { Component, OnInit, Inject } from '@angular/core';
import { PassageListItem } from 'src/app/services/stops.service';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { TTSSXApiService } from 'src/app/services/ttssxapi.service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-save-passage-dialog',
  templateUrl: './save-passage-dialog.component.html',
  styleUrls: ['./save-passage-dialog.component.scss']
})
export class SavePassageDialogComponent implements OnInit {
  tramNo: string;
  constructor(@Inject(MAT_DIALOG_DATA) public dialogData: PassageListItem, private ttssxService: TTSSXApiService, private dialogRef: MatDialogRef<SavePassageDialogComponent>) { }

  ngOnInit() {
  }

  save() {
    this.ttssxService.savePassage(this.dialogData, this.tramNo)
      .subscribe(d => this.dialogRef.close());
  }
}
