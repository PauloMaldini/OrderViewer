import {Component, Input, OnInit} from '@angular/core';
import {OrderSummaryItemDto} from "../../../../../../shared/generated";

@Component({
  selector: 'app-summary-items',
  templateUrl: './summary-items.component.html',
  styleUrls: ['./summary-items.component.css']
})
export class SummaryItemsComponent implements OnInit {

  @Input() orderSummaryItems: {
    totalQty: number,
    totalProductPrice: number,
    totalPrice: number,
    items: OrderSummaryItemDto[]
  }

  constructor() { }

  ngOnInit() {
  }
}
