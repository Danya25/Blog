import {ApplicationConfig, importProvidersFrom} from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import {HTTP_INTERCEPTORS, provideHttpClient} from "@angular/common/http";
import {provideToastr} from "ngx-toastr";
import {provideAnimations} from "@angular/platform-browser/animations";
import {JwtModule} from "@auth0/angular-jwt";

export function tokenGetter(): string | null {
  return localStorage.getItem('token');
}
export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes), provideToastr(), provideAnimations(), provideHttpClient(), importProvidersFrom(
    JwtModule.forRoot({
      config: {
        tokenGetter
      }
    }),
  ) ]
};
