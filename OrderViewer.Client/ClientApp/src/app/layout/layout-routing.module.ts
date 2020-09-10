import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { LayoutComponent } from './layout.component';

const routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      { path: '', loadChildren: '../pages/order/order.module#OrderModule' },
    ]
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class LayoutRoutingModule { }
