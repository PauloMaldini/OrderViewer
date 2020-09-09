import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { OrderRoutingModule } from './order-routing.module';
import { OrderComponent } from './order.component';
import { NavigationComponent } from './components/navigation/navigation.component';
import { SummaryComponent } from './components/summary/summary.component';
import { SummaryHeadingComponent } from './components/summary/components/summary-heading/summary-heading.component';
import { SummaryItemsComponent } from './components/summary/components/summary-items/summary-items.component';


@NgModule({
  declarations: [OrderComponent, NavigationComponent, SummaryComponent, SummaryHeadingComponent, SummaryItemsComponent],
  imports: [
    CommonModule,
    OrderRoutingModule
  ]
})
export class OrderModule { }
