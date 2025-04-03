import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { AuthResponseModel, Login } from '../../models/login';
import { UserService } from '../../services/user.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  loginModel: Login = new Login('', '');
  errorMsg='';
  


  constructor(private userService: UserService,private router:Router) {}

  

  ngonInit() {
    
  }
  
  loginUser(loginForm: NgForm) {
    this.loginModel = loginForm.value;
    console.log(this.loginModel);
    this.userService.login(this.loginModel).subscribe({
      next: (response: AuthResponseModel) => {
        console.log('Login Success', response);
        localStorage.setItem('userId', response.id);
        
        
        localStorage.setItem('token', response.token);
        alert('Login Success');
        
        loginForm.reset();

        this.router.navigate(['product']);

      },
      error: (error) => {
        console.error('Login Failed', error);
        this.errorMsg= JSON.stringify(error.error.message);
        alert(this.errorMsg);
        
      },
    });
  }
}
