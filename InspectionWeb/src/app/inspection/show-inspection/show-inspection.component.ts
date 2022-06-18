import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { InspectionApiService } from 'src/app/inspection-api.service';
import { Inspection } from 'src/app/Models/Inspection.class';
import { InspectionType } from 'src/app/Models/InspectionType.class';
@Component({
  selector: 'app-show-inspection',
  templateUrl: './show-inspection.component.html',
  styleUrls: ['./show-inspection.component.scss']
})
export class ShowInspectionComponent implements OnInit {

  InspectionList!: Observable<Inspection[]>;
  InspectionTypesList!:Observable<InspectionType[]>;
  InspectionTypeList:any = [];

  constructor(private service:InspectionApiService) { }

  ngOnInit(): void {
    this.InspectionList = this.service.GetInspectionsList();
  }

}
