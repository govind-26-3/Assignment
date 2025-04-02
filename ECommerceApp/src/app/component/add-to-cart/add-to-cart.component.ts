import { Component, OnInit } from '@angular/core';
import { Cart } from '../../models/cart';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-add-to-cart',
  standalone: true,
  imports: [],
  templateUrl: './add-to-cart.component.html',
  styleUrl: './add-to-cart.component.css'
})
export class AddToCartComponent {
  
  products: Array<any> = [];
  cartItems: Array<any> = [];
  
  ngOnInit(): void {
    this.loadProducts();
  }
  constructor(private http: HttpClient) { }

    loadProducts(): void {
      this.http.getAllProducts().subscribe((data: any) => {
        this.products = data.data;
      });
    }
  
    addItemToCart(productId: string, quantity: number): void {
      const payload = { productId, quantity };
      this.http.addToCart(payload).subscribe(() => {
        alert('Product added to cart');
      });
    }
  }
}
