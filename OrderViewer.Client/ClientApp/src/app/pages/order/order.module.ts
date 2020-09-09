import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrderRoutingModule } from './order-routing.module';
import { OrderComponent } from './order.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { SummaryComponent } from './components/summary/summary.component';
import { SummaryHeadingComponent } from './components/summary/components/summary-heading/summary-heading.component';
import { SummaryItemsComponent } from './components/summary/components/summary-items/summary-items.component';
import { NavListComponent } from './components/navigation/components/nav-list/nav-list.component';
import { NavFooterComponent } from './components/navigation/components/nav-footer/nav-footer.component';


@NgModule({
  declarations: [OrderComponent, NavigationComponent, SummaryComponent, SummaryHeadingComponent, SummaryItemsComponent, NavListComponent, NavFooterComponent],
  imports: [
    CommonModule,
    OrderRoutingModule
  ]
})
export class OrderModule { }
