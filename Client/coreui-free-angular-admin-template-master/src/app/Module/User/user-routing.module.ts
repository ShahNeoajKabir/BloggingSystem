
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AddUserComponent } from './add-user/add-user.component';
import { DeleteUserComponent } from './delete-user/delete-user.component';
import { StuffListComponent } from './stuff-list/stuff-list.component';
import { UserListComponent } from './user-list/user-list.component';


const routes: Routes = [{ path: 'AddUser', component: AddUserComponent },
{path:':id/edit', component:AddUserComponent },
{ path: 'ViewUser', component: UserListComponent },
{ path: 'ViewStuff', component: StuffListComponent },
{path:':id/delete', component:DeleteUserComponent },









];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UserRoutingModule { }