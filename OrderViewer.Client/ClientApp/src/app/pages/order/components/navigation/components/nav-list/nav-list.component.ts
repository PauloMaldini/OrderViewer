import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {OrderDto} from "../../../../../../shared/generated";

@Component({
  selector: 'app-nav-list',
  templateUrl: './nav-list.component.html',
  styleUrls: ['./nav-list.component.css']
})
export class NavListComponent implements OnInit {

  @Input() orders : OrderDto[];
  @Output() selected = new EventEmitter<number>();

  activeIndex: number = 0;

  constructor() { }

  ngOnInit() {
  }

  onItemClick(index: number) {
    this.activeIndex = index;
    this.selected.emit(this.orders[index].id);
  }
}
