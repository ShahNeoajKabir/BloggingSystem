
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { AddRoleComponent } from './add-role/add-role.component';
import { DeleteRoleComponent } from './delete-role/delete-role.component';
import { ListRoleComponent } from './list-role/list-role.component';


const routes: Routes = [{ path: 'AddRole', component: AddRoleComponent },
{path:':id/edit', component:AddRoleComponent },
{ path: 'ViewRole', component: ListRoleComponent },
{path:':id/delete', component:DeleteRoleComponent },









];

@NgModule({
  imports: [RouterModule.forChild(routes) , ToastrModule.forRoot()],
  exports: [RouterModule]
})
export class RoleRoutingModule { }