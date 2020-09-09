import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutComponent } from './layout.component';
import {LayoutRoutingModule} from "./layout-routing";

@NgModule({
  declarations: [LayoutComponent],
  imports: [
    LayoutRoutingModule
  ]
})
export class LayoutModule { }
