export interface Product {

    productId: number;
    pName: string;
    description: string;
    price: number;
    quantity: number;
    category?: Category;
    // imageUrl: string;

}

export interface Category {
    id: number;
    name: string;
    description: string;
   
}