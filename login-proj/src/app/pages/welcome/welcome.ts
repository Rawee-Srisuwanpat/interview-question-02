import { ChangeDetectorRef, Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth';

@Component({
  selector: 'app-welcome',
  standalone: true,
  templateUrl: './welcome.html',
  styleUrl: './welcome.css'
})
export class Welcome {

  user = '';

  constructor(
    private router: Router,
    private auth: AuthService,
    private cd: ChangeDetectorRef
  ) { }

  ngOnInit() {
    this.getProfile();
  }

  getProfile() {
    this.auth.getProfile({
      UserId: localStorage.getItem("user")
    }).subscribe({

      next: (res: any) => {
        if (res.statusCode == "00") {

          this.user = res.username

          this.cd.detectChanges();
        } else {
          alert(res.statusText);
        }

      }

    });
  }

  logout() {
    localStorage.clear()

    this.router.navigate(
      ['/'],
      {
        replaceUrl: true
      }
    );
  }

}