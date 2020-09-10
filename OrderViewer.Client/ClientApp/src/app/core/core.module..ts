import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {clientServiceProvider} from "./common/providers";

@NgModule({
  declarations: [],
  imports: [
    CommonModule
  ],
  providers: [
    clientServiceProvider
  ]
})
export class CoreModule { }
