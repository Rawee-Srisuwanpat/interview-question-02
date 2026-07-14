import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  standalone:true,
  imports:[FormsModule],
  templateUrl:'./register.html',
  styleUrl:'./register.css'
})
export class Register{

    user='';

    password='';

    confirmPassword='';

    constructor(private auth:AuthService , private router:Router){}

    register(){

        if(this.password!=this.confirmPassword){

            alert("Password ไม่ตรงกัน");

            return;

        }

        this.auth.register({

            username:this.user,

            password:this.password,
            confirmPassword :this.confirmPassword,

        }).subscribe({

            next:()=>{

                alert("สมัครสมาชิกสำเร็จ");

            }

        });

    }

    backTologin() {
        this.router.navigate(['/']);
    }
   

}