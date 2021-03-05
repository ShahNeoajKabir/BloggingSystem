import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { AddRoleComponent } from './add-role/add-role.component';
import { ListRoleComponent } from './list-role/list-role.component';
import { DeleteRoleComponent } from './delete-role/delete-role.component';
import { RoleService } from '../../Services/Role/role.service';
import { RoleRoutingModule } from './role-routing.module';




@NgModule({
  declarations: [AddRoleComponent,  ListRoleComponent, DeleteRoleComponent ],
  imports: [
    CommonModule,
    RoleRoutingModule,
    FormsModule
  ],
  providers:[RoleService],
})
export class RoleModule { }