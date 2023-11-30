import { Injectable } from '@angular/core';
import {
  HttpEvent,
  HttpInterceptor,
  HttpHandler,
  HttpRequest,
} from '@angular/common/http';
import { Observable, finalize } from 'rxjs';
import { LoaderService } from '../../persons/services/loader.service';
import { pipe, tap, map, switchMap } from 'rxjs'
import { OidcSecurityService } from 'angular-auth-oidc-client';
@Injectable()
export class AppHttpInterceptor implements HttpInterceptor {

  constructor(private oidcSecurityService: OidcSecurityService) { }

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<unknown>> {
    return this.oidcSecurityService.getAccessToken().pipe(
      switchMap(token => {
        if (token) {
          request = request.clone({
            setHeaders: { Authorization: `Bearer ${token}` }
          });
        }
        return next.handle(request);
      })
    );
  }
}