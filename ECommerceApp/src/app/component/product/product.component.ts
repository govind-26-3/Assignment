import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Product } from '../../models/product';
import { ProductService } from '../../services/product.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-product',
  standalone: true,
  imports: [FormsModule,CommonModule],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent implements OnInit{
  products: Product[]=[];

  ngOnInit(): void {
     this.getProducts();
  }
  constructor(private productService: ProductService,private router:Router) { }

  getProducts():void {

    this.productService.getAllProducts().subscribe(res=>{
      console.log(res);
      this.products=res;
    }

    )}
  
  oncart(){
    this.router.navigate(['/add-to-cart']);

  }

  
}
