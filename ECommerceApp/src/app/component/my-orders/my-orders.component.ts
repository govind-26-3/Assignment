import { CommonModule, DatePipe } from '@angular/common';
import { Component } from '@angular/core';
import { OrderStatus } from '../../constants';
import { OrdersService } from '../../services/orders.service';
import { Order } from '../../models/order';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-my-orders',
  standalone: true,
  imports: [DatePipe,FormsModule,CommonModule],
  templateUrl: './my-orders.component.html',
  styleUrl: './my-orders.component.css'
})
export class MyOrdersComponent {
  orderStatus = OrderStatus

  constructor(private orderService:OrdersService) { }

userId = localStorage.getItem('userId');
ngOnInit(): void {
  if (this.userId) {
    this.getOrders(this.userId);
  } else {
    console.error('User ID is null');
  }
}
  orders: any[]=[];
  
  getOrders(userId:string): void {
    this.orderService.getOrders(userId).subscribe((response) => {
      console.log(response);
      this.orders = response;
    });
  }
 
}
