import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { UserService } from '../../Services/User/user.service';
import { UserRoleService } from '../../Services/UserRole/user-role.service';
import { UserRoleRoutingModule } from './userrole-routing.module';
import { AddUserRoleComponent } from './add-user-role/add-user-role.component';
import { ListUserRoleComponent } from './list-user-role/list-user-role.component';
import { DeleteUserRoleComponent } from './delete-user-role/delete-user-role.component';
import { UpdateUserRoleComponent } from './update-user-role/update-user-role.component';




@NgModule({
  declarations: [AddUserRoleComponent, ListUserRoleComponent, DeleteUserRoleComponent, UpdateUserRoleComponent],
  imports: [
    CommonModule,
    UserRoleRoutingModule,
    FormsModule
  ],
  providers:[UserRoleService],
})
export class UserRoleModule { }