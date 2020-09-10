import { Component, OnInit } from '@angular/core';
import {OrderDto, OrderSummaryDto} from "../../shared/generated";

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  orders: OrderDto[];
  orderSummary: OrderSummaryDto;

  constructor() { }

  ngOnInit() {

  }

  onSelectOrder(orderId : number) {
    //Refresh orderSummary
  }
}
