import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class CustomInterceptorService implements HttpInterceptor {
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token=localStorage.getItem('token');//to get token from localStorage
    if(token){
      const clonedRequest=req.clone({
        setHeaders:{
          Authorization:`Bearer ${token}`
        }
      });
      return next.handle(clonedRequest);
    }
    return next.handle(req);
  }


  constructor() { }
}
