import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ErrorHandlingInterceptor } from './interceptors/error-handling.interceptor';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { AuthService } from './services/auth.service';

@NgModule({
  declarations: [],
  imports: [HttpClientModule],
  exports: [],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true,
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorHandlingInterceptor,
      multi: true,
    },
    AuthService
  ],
})
export class CoreModule {}
