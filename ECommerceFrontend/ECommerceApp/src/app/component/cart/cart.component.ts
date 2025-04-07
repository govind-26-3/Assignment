import { Component, OnInit } from '@angular/core';
import { CartService } from '../../services/cart.service';
import { Cart } from '../../models/cart';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { OrdersService } from '../../services/orders.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-cart',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './cart.component.html',
  styleUrl: './cart.component.css',
})
export class CartComponent {
  constructor(
    private cartService: CartService,
    private orderService: OrdersService,
    private router: Router
  ) {}

  orderNow(cartItemId: number): void {
    this.orderService.orderNow(cartItemId).subscribe({
      next: () => {
        Swal.fire({
          title: 'Order Placed Successfully!',
          text: 'Your order has been successfully placed.',
          icon: 'success',
          confirmButtonText: 'OK',
        });

        this.router.navigate(['product']);
      },
      error: (error) => {
        console.error('Order Failed', error);
        Swal.fire({
          title: 'Order Failed',
          text: 'There was an issue placing your order. Please try again.',
          icon: 'error',
          confirmButtonText: 'Try Again',
        });
      },
    });
  }

  cartItems: Cart[] = [];

  ngOnInit(): void {
    this.getCartItems();
  }

  getCartItems(): void {
    this.cartService.getCartItems().subscribe((response) => {
      this.cartItems = response;
    });
  }
  removeItem(productId: number): void {
    this.cartService.removeFromCart(productId).subscribe(() => {
      alert('Item removed from cart');
      this.getCartItems();
    });
  }

  // removeItem(productId: number): void {

  //   this.cartItems = this.cartItems.filter(item => item.productId !== productId);
  //   alert('Item removed from cart');
  // }

  // clearCart(): void {

  //   this.cartItems = [];
  //   alert('Cart cleared');
  // }
}
