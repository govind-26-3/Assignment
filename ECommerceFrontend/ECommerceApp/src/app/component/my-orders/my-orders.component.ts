import { CommonModule, DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { OrderStatus } from '../../constants';
import { OrdersService } from '../../services/orders.service';
import { Order } from '../../models/order';
import { FormsModule } from '@angular/forms';
import { OrderItemService } from '../../services/order-item.service';

@Component({
  selector: 'app-my-orders',
  standalone: true,
  imports: [DatePipe,FormsModule,CommonModule],
  templateUrl: './my-orders.component.html',
  styleUrl: './my-orders.component.css'
})
export class MyOrdersComponent {
  orderStatus = OrderStatus

  orders: any[]=[];
  orderItems: any[]=[];
  
  constructor(private orderService:OrdersService,private orderItem:OrderItemService) { }

userId = localStorage.getItem('userId');

ngOnInit(): void {
  // this.getOrders();
  this.getOrders();
  // if (this.userId) {
  //   this.getOrders(this.userId);
  // } else {
  //   console.error('User ID is null');
  // }
}
  // getOrders(userId:string): void {
  //   this.orderService.getOrders(userId).subscribe((response) => {
  //     console.log(response);
  //     this.orders = response;
  //   });
  // }
  getOrders(): void {
    this.orderService.getOrders().subscribe((response) => {
      console.log(response);
      this.orders = response;
    });
  }
  getOrderItems(orderId:number): void {
    this.orderItem.getOrderItems(orderId).subscribe((response) => {
      console.log(response);
      this.orderItems = response;
    });
  }
 
}
