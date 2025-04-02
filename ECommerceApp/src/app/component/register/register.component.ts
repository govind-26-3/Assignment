
import { Component, OnInit } from '@angular/core';
import {  FormsModule, NgForm, ReactiveFormsModule, Validators } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { Register, RegistrationResponse } from '../../models/register';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule,FormsModule,RouterModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  
  registerModel: Register = new Register('','','','');
 errorMsg='';
 
   constructor( private userService: UserService,private router:Router) {
     }
  ngOnInit(){
    

    }

  
  
  RegisterUser(registerForm:NgForm){
    this.registerModel = registerForm.value;
    console.log(this.registerModel);

    this.userService.register(this.registerModel).subscribe({
      next:(response:RegistrationResponse)=>{
        console.log(response);
        alert('Registration Success');
        // this.registerModel.;
        registerForm.reset();
       this.router.navigate(['login']);
      //  this.routerService.goToLogin();
        
      },
      error:(err)=>{
        console.error('register Failed:',err)
        this.errorMsg=JSON.stringify(err.error)
        alert(this.errorMsg);
      }
      
    })
  }
}
