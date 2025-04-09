import { Component } from '@angular/core';
import Swal from 'sweetalert2';
import { ProductService } from '../../services/product.service';
import { FormsModule, NgForm } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Product } from '../../models/product';

@Component({
  selector: 'app-add-product',
   standalone: true,
   imports: [ FormsModule, CommonModule],
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent {

 
  product  = new Product();

  constructor(private productService: ProductService) {}

  addProduct(productForm: NgForm) {
    this.product = productForm.value;
    console.log(this.product);
    
    this.productService.addProduct(this.product).subscribe({
      next: (response) => {
        Swal.fire({
          title: 'Success!',
          text: 'Product added successfully!',
          icon: 'success',
          confirmButtonText: 'OK'
        });
        
      },
      error: (error) => {
        console.error('Error adding product:', error);
        Swal.fire({
          title: 'Error!',
          text: 'There was an error adding the product.',
          icon: 'error',
          confirmButtonText: 'Try Again'
        });
      }
    });
  }

  
}