import {  Product } from "./product";

export interface Cart {
    cartItemId: number;
    userId: number;
    productId: number;
    product?: Product;
    quantity: number;
}

