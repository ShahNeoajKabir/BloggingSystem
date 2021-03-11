
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { AddPostComponent } from './add-post/add-post.component';
import { DeletePostComponent } from './delete-post/delete-post.component';
import { ListPostComponent } from './list-post/list-post.component';
import { UpdatePostComponent } from './update-post/update-post.component';


const routes: Routes = [{ path: 'AddPost', component: AddPostComponent },
{path: 'View', component:ListPostComponent},
{path: ':id/edit' , component:UpdatePostComponent},
{path: ':id/delete', component:DeletePostComponent}










];

@NgModule({
  imports: [RouterModule.forChild(routes) , ToastrModule.forRoot()],
  exports: [RouterModule]
})
export class PostRoutingModule { }