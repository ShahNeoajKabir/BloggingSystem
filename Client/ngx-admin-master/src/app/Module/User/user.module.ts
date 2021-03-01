import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddUserComponent } from './add-user/add-user.component';
import { ListUserComponent } from './list-user/list-user.component';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../Services/User/user.service';
import { UserRoutingModule } from './user-routing.module';




@NgModule({
  declarations: [AddUserComponent, ListUserComponent, CustomerListComponent ],
  imports: [
    CommonModule,
    UserRoutingModule,
    FormsModule
  ],
  providers:[UserService],
})
export class UserModule { }