import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { Router, RouterModule } from '@angular/router';
import { ThisReceiver } from '@angular/compiler';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterModule,FormsModule,CommonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit {

  // isLoggedIn:boolean=false;
  // email:string|null='';

  
  constructor( public userService:UserService,private router:Router) {}

    ngOnInit(): void {
      
    }
    logOut(){
      localStorage.clear();
     this.router.navigate(['/login']);
    }
}
