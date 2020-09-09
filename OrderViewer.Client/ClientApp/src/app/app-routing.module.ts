import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

const routes = [
  { path: '', loadChildren: './layout/layout.module#LayoutModule' }
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }
