import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AuthService } from '../../services/auth';
import { RouterLink } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone:true,
  imports: [FormsModule, CommonModule,RouterLink],
  templateUrl: './login.html',
  styleUrl: './login.css'
})
export class Login {

  user = '';
  password = '';

  constructor(
    private auth:AuthService,
    private router:Router
  ){}

  login(){

    const body = {
      username:this.user,
      password:this.password
    };

    this.auth.login(body).subscribe({

      next:(res:any)=>{

        if(res.statusCode =="00"){

          localStorage.setItem("user",res.userId);

          localStorage.setItem(
            'token',
            res.token
          );

          this.router.navigate(['/welcome']);

        }else {
          alert(res.statusText);
        }

      },

      error:()=>{

        alert("Login Fail");

      }

    });

  }

}