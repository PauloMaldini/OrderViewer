import {Component, Inject, OnInit} from '@angular/core';
import {IClient, OrderDto, OrderSummaryDto} from "../../shared/generated";
import {clientServiceToken} from "../../core/common/providers";

@Component({
  selector: 'app-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.css']
})
export class OrderComponent implements OnInit {

  orders: OrderDto[];
  orderSummary: OrderSummaryDto;

  constructor(@Inject(clientServiceToken) private client : IClient) { }

  ngOnInit() {
    console.log(this.client);
    this.client.ordersAll(null, null, null, null)
      .then((x) => this.orders = x);
  }

  onSelectOrder(orderId : number) {
    //Refresh orderSummary

  }
}
