import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {OrderDto} from "../../../../shared/generated";

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {

  @Input() orders : OrderDto[];
  @Output() selected = new EventEmitter<number>();

  constructor() { }

  ngOnInit() {
  }

  onItemClick(orderId: number) {
    this.selected.emit(orderId);
  }
}
