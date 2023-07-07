import {NgModule} from '@angular/core';
import {CommonModule} from "@angular/common";
import {RouterModule} from "@angular/router";
import {AppRoutingModule} from "./app-routing.module";
import {ROUTES} from "./app.routes";
import {FullLayoutComponent} from "./conteiners/full-layout/full-layout/full-layout.component";
import {AppComponent} from "./app.component";

const layoutComponents = [
  FullLayoutComponent
];
const appComponents = [
  AppComponent
]
@NgModule({
  declarations: [
    ...layoutComponents,
    ...appComponents,
  ],
  imports: [
    CommonModule,
    AppRoutingModule,
  ],
  exports: [RouterModule]
})
export class AppModule{}
