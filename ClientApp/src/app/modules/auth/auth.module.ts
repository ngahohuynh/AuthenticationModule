import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { ReactiveFormsModule } from "@angular/forms";
import { CoreModule } from "src/app/core/core.module";
import { MaterialModule } from "src/app/shared/material.module";
import { SharedModule } from "src/app/shared/shared.module";
import { LoginPageComponent } from "./pages/login-page/login-page.component";
import { RegisterPageComponent } from "./pages/register-page/register-page.component";

@NgModule({
  declarations: [
    LoginPageComponent,
    RegisterPageComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,

    SharedModule,
    CoreModule,
    MaterialModule
  ],
  exports: [
    LoginPageComponent,
    RegisterPageComponent
  ],
  providers: []
})
export class AuthModule {

}
