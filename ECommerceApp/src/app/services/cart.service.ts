import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cart } from '../models/cart';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  private apiUrl = 'https://localhost:7252/api/Cart';
  constructor(private http:HttpClient) { }

  addToCart(productId: number, quantity: number) {
    const cartItem = { productId, quantity };
    return this.http.post(`${this.apiUrl}/add`, cartItem);
  }
  getCartItems():Observable<Cart[]>{
    return this.http.get<Cart[]>(`${this.apiUrl}/items`);
  }
  removeFromCart(productId: number) {
    return this.http.delete(`${this.apiUrl}/remove/${productId}`);
  }
  clearCart() {
    return this.http.delete(`${this.apiUrl}/clear`);
  }
  updateCartItem(productId: number, quantity: number) {
    const cartItem = { productId, quantity };
    return this.http.put(`${this.apiUrl}/update`, cartItem);
  }

}
