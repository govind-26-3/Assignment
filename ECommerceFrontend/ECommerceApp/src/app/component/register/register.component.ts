import { Component, OnInit } from '@angular/core';
import {
  FormsModule,
  NgForm,
  
} from '@angular/forms';
import { UserService } from '../../services/user.service';
import { CommonModule } from '@angular/common';
import { Router, RouterModule } from '@angular/router';
import { Register, RegistrationResponse } from '../../models/register';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css',
})
export class RegisterComponent {
  registerModel: Register = new Register('', '', '', '');
  errorMsg = '';

  constructor(private userService: UserService, private router: Router) {}
  ngOnInit() {}

  RegisterUser (registerForm: NgForm) {
    this.registerModel = registerForm.value;
    console.log(this.registerModel);
  
    this.userService.register(this.registerModel).subscribe({
      next: (response: RegistrationResponse) => {
        console.log(response);
        Swal.fire({
          title: 'Registration Success',
          text: 'You have successfully registered!',
          icon: 'success',
          confirmButtonText: 'OK'
        });
  
        registerForm.reset();
        this.router.navigate(['login']);
      },
      error: (err) => {
        console.error('Register Failed:', err);
        this.errorMsg = JSON.stringify(err.error);
        Swal.fire({
          title: 'Registration Failed',
          text: this.errorMsg,
          icon: 'error',
          confirmButtonText: 'Try Again'
        });
      },
    });
  }
}
