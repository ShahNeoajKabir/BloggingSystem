import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { SecurityService } from '../Services/Security/security.service';
import { UserService } from '../Services/User/user.service';
import { SigninRoutingModule } from './signin-routing.module';
import { SigninComponent } from './signin/signin.component';
import { RegistrationComponent } from './registration/registration.component';
import { ChangPasswordComponent } from './chang-password/chang-password.component';



@NgModule({
  declarations: [ SigninComponent, RegistrationComponent, ChangPasswordComponent],
  imports: [
    CommonModule,
    SigninRoutingModule,
    FormsModule
  ],
  providers:[SecurityService,UserService ],
})
export class SigninModule { }