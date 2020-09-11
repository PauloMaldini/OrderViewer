import {Component, EventEmitter, HostBinding, HostListener, Input, OnInit, Output} from '@angular/core';
import {OrderDto, OrderStatus} from "../../../../../../../../shared/generated";

@Component({
  selector: 'app-nav-list-item',
  templateUrl: './nav-list-item.component.html',
  styleUrls: ['./nav-list-item.component.css']
})
export class NavListItemComponent implements OnInit {

  @Input() order: OrderDto;
  @Input() isActive: boolean;
  @Input() index: number;
  @Output() selected = new EventEmitter<number>();

  // @HostBinding('style.background-color')
  // backgroundColor = 'white';

  constructor() { }

  ngOnInit() {

  }

  @HostListener("click") onClick() {
    this.selected.emit(this.index);
  }
}
