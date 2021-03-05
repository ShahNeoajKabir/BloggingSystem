import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddUserComponent } from './add-user/add-user.component';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../Services/User/user.service';
import { UserRoutingModule } from './user-routing.module';
import { UserListComponent } from './user-list/user-list.component';
import { StuffListComponent } from './stuff-list/stuff-list.component';
import { DeleteUserComponent } from './delete-user/delete-user.component';
import { UnAssignUserComponent } from './un-assign-user/un-assign-user.component';




@NgModule({
  declarations: [AddUserComponent,  UserListComponent, StuffListComponent, DeleteUserComponent, UnAssignUserComponent ],
  imports: [
    CommonModule,
    UserRoutingModule,
    FormsModule
  ],
  providers:[UserService],
})
export class UserModule { }