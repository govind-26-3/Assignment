import {  Product } from "./product";

export interface Cart {
    cartItemId: number;
    userId: number;
    product?: Product;
    quantity: number;
}

