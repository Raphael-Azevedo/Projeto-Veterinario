import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HTTP_INTERCEPTORS
} from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable()
export class AuthInterceptor implements HttpInterceptor {

  constructor() {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    console.log('inside intercept');
    console.log(`request is ${JSON.stringify(request.body)}`);
    request = request.clone({ headers: request.headers.set('Authorization', `Bearer ${sessionStorage.getItem("auth-token")}`) });
    return next.handle(request);
  }
    }

export const AuthInterceptorProvider = { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true };

