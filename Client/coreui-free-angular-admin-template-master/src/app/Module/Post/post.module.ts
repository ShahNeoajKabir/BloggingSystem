import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { PostRoutingModule } from './post-routing.module';
import { PostService } from '../../Services/Post/post.service';
import { AddPostComponent } from './add-post/add-post.component';
import { UpdatePostComponent } from './update-post/update-post.component';
import { ListPostComponent } from './list-post/list-post.component';
import { DeletePostComponent } from './delete-post/delete-post.component';




@NgModule({
  declarations: [ AddPostComponent, UpdatePostComponent, ListPostComponent, DeletePostComponent],
  imports: [
    CommonModule,
    PostRoutingModule,
    FormsModule
  ],
  providers:[PostService],
})
export class PostModule { }