
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { AddUserComponent } from './add-user/add-user.component';
import { DeleteUserComponent } from './delete-user/delete-user.component';
import { StuffListComponent } from './stuff-list/stuff-list.component';
import { UnAssignUserComponent } from './un-assign-user/un-assign-user.component';
import { UpdateUserComponent } from './update-user/update-user.component';
import { UserListComponent } from './user-list/user-list.component';


const routes: Routes = [{ path: 'AddUser', component: AddUserComponent },
// {path:':id/edit', component:AddUserComponent },
{path:':id/edit', component:UpdateUserComponent },
{ path: 'ViewUser', component: UserListComponent },
{ path: 'ViewStuff', component: StuffListComponent },
{path:':id/delete', component:DeleteUserComponent },
{path:'ViewUnAssignUser', component:UnAssignUserComponent },










];

@NgModule({
  imports: [RouterModule.forChild(routes), ToastrModule.forRoot()],
  exports: [RouterModule]
})
export class UserRoutingModule { }