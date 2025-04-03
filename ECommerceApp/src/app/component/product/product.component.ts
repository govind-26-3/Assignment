import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Product } from '../../models/product';
import { ProductService } from '../../services/product.service';
import { Route, Router, RouterModule } from '@angular/router';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [FormsModule,CommonModule,RouterModule],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent implements OnInit{
  products: Product[]=[];

  ngOnInit(): void {
     this.getProducts();
  }
  constructor(private productService: ProductService,private router:Router, public userService:UserService) { }

  getProducts():void {

    this.productService.getAllProducts().subscribe(res=>{
      console.log(res);
      this.products=res;
    }

    )}
  
    addItemToCart(productId: number, quantity: number): void {

      if (!this.userService.isLoggedIn()) {
       
        this.router.navigate(['/login']);
      } else {
        
       
        const payload = { productId, quantity };
        this.productService.addToCart(payload).subscribe(() => {
          alert('Product added to cart');
          
          this.getProducts();
        });
      }
    }
  }

  

