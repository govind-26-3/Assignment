import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { OrderItems } from '../models/order-items';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root',
})
export class OrderItemService {
  private apiUrl = 'https://localhost:7252/api/OrderItem';
  constructor(private http: HttpClient) {}

  getOrderItems(orderId: number): Observable<OrderItems[]> {
    return this.http.get<OrderItems[]>(`${this.apiUrl}/${orderId}`);
  }
}
