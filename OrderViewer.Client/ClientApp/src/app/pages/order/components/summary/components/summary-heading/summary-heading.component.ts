import {Component, Input, OnInit} from '@angular/core';
import {OrderStatus} from "../../../../../../shared/generated";

@Component({
  selector: 'app-summary-heading',
  templateUrl: './summary-heading.component.html',
  styleUrls: ['./summary-heading.component.css']
})
export class SummaryHeadingComponent implements OnInit {

  @Input() orderSummaryHeading: {
    number?: string | undefined,
    date?: Date,
    status?: OrderStatus,
    stateName?: string | undefined
  }

  constructor() { }

  ngOnInit() {
  }
}
