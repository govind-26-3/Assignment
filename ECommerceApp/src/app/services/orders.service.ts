import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Order } from '../models/order';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
private apiUrl='https://localhost:7252/api/Order';
  constructor(private http:HttpClient) { }

  // getOrders(): Observable<Order[]> {
  //   return this.http.get<Order[]>(`${this.apiUrl}`);
  // }
  getOrders(userId:string): Observable<Order[]> {
    return this.http.get<Order[]>(`${this.apiUrl}/${userId}`);
  }

orderNow(cartItemId:number ) {
    return this.http.post(`${this.apiUrl}`, cartItemId);
  }
}
