import { Order } from "./order";

export interface OrderItems {
    orderItemId: number;
    orderId: number;
    orders?:Order;
    productId: number;
    Quantity: number;
}
