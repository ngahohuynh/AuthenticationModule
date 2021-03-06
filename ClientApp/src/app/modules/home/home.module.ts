import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { CoreModule } from "src/app/core/core.module";
import { MaterialModule } from "src/app/shared/material.module";
import { SharedModule } from "src/app/shared/shared.module";
import { HomePageComponent } from "./home-page/home-page.component";

@NgModule({
  declarations: [
    HomePageComponent
  ],
  imports: [
    CommonModule,

    SharedModule,
    CoreModule,
    MaterialModule
  ],
  exports: [
    HomePageComponent
  ],
  providers: []
})
export class HomeModule {

}
