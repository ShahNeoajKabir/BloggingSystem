import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../Common/Auth/auth.service';
import { VMLogin } from '../../Model/VMLogin';
import { SecurityService } from '../../Services/Security/security.service';

@Component({
  selector: 'app-signin',
  templateUrl: './signin.component.html',
  styleUrls: ['./signin.component.scss']
})
export class SigninComponent implements OnInit {

  public objLogin:VMLogin=new VMLogin();

  constructor(private Securityservice: SecurityService, private router: Router, private authservice: AuthService) { }

  ngOnInit(): void {
  }
  Login() {
    this.authservice.login(this.objLogin).subscribe(res => {

      // tslint:disable-next-line:triple-equals
        if (this.authservice.getLoggedUserType() === 3) {
        console.log(this.authservice.getLoggedUserType());

        this.router.navigate(['/CustomerDashboard/Profile']);
        } else {
          this.router.navigate(['/dashboard']);

        }

    }
    );
  }
}
