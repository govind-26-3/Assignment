import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit {

  isLoggedIn:boolean=false;
  email:string|null='';

  
  constructor( public userService:UserService) {}

    ngOnInit(): void {
      // this.userService.isLoggedIn$.subscribe((loggedIn)=>{
      //   this.isLoggedIn=loggedIn;
      //   this.email=localStorage.getItem('email');
      // })
     
    }
}
