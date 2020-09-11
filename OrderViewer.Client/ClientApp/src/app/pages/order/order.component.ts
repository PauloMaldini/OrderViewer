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
    this.client.ordersAll(null, null, null, null)
      .then((x) => {
        this.orders = x;
        if (x.length > 0) {
          this.onSelectOrder(x[0].id);
        }
      });
  }

  onSelectOrder(orderId : number) {
    this.client.orderSummary(orderId)
      .then((x) => {
        console.log(x);
        this.orderSummary = x.items[0];

      });
  }
}
