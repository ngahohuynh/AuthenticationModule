import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { HeaderComponent } from "./components/header/header.component";
import { MaterialModule } from "./material.module";

@NgModule({
  declarations: [
    HeaderComponent
  ],
  imports: [
    CommonModule,
    
    MaterialModule
  ],
  exports: [
    HeaderComponent
  ],
  providers: []
})
export class SharedModule {

}
