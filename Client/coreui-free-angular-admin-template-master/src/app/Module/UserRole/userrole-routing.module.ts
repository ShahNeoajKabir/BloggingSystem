
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { AddUserRoleComponent } from './add-user-role/add-user-role.component';
import { DeleteUserRoleComponent } from './delete-user-role/delete-user-role.component';
import { ListUserRoleComponent } from './list-user-role/list-user-role.component';
import { UpdateUserRoleComponent } from './update-user-role/update-user-role.component';

const routes: Routes = [{ path: ':id/AddUserRole', component: AddUserRoleComponent },
{path:':id/edit', component:UpdateUserRoleComponent },
{ path: 'View', component: ListUserRoleComponent },
{path:':id/delete', component:DeleteUserRoleComponent },









];

@NgModule({
  imports: [RouterModule.forChild(routes),ToastrModule.forRoot()],
  exports: [RouterModule]
})
export class UserRoleRoutingModule { }