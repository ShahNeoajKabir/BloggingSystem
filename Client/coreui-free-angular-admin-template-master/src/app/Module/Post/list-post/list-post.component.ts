import { Component, OnInit } from '@angular/core';
import { Post } from '../../../Model/Post';
import { PostService } from '../../../Services/Post/post.service';

@Component({
  selector: 'app-list-post',
  templateUrl: './list-post.component.html',
  styleUrls: ['./list-post.component.scss']
})
export class ListPostComponent implements OnInit {
  public lstpost:Post[]=new Array<Post>();

  constructor(private readonly postservice:PostService) { }

  ngOnInit(): void {
    this.postservice.GetAll().subscribe((res:any)=>{
      this.lstpost=res;
      console.log(this.lstpost);
    })
  }

}
