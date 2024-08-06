import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { request } from 'express';
@Injectable()
export class tokeninterceptorInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) { }
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    // Get the token from the AuthService
    const token = this.authService.getToken();
    //console.log("Token received from interceptor: ", token);
    if (token) {
     // console.log("Token received from interceptor part 2: ", token);
      // Clone the request and add the authorization header with the token
      request = request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`
        }
      });
    }

    return next.handle(request);
  }
}
