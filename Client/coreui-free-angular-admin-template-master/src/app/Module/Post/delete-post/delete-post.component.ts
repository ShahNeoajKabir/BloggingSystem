import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Utility } from '../../../Common/Utility';
import { Post } from '../../../Model/Post';
import { CategoriesService } from '../../../Services/Categories/categories.service';
import { NotificationService } from '../../../Services/Notification/notification.service';
import { PostService } from '../../../Services/Post/post.service';

@Component({
  selector: 'app-delete-post',
  templateUrl: './delete-post.component.html',
  styleUrls: ['./delete-post.component.scss']
})
export class DeletePostComponent implements OnInit {
  public objpost:Post=new Post();
  public delete:Post=new Post();

  public lstcategories:any;
  public lstStatus:any;

  constructor(
    private postService:PostService ,
    private categorieservice:CategoriesService,
    private router:Router,
    private notification:NotificationService,
    private utility:Utility,
    private ActivateRouter:ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.categorieservice.GetAll().subscribe((res:any)=>{
      this.lstcategories=res;
      console.log(this.lstcategories);

    })
    if (this.ActivateRouter.snapshot.params['id'] !== undefined) {

      this.delete.PostId = this.ActivateRouter.snapshot.params['id' ];
      this.postService.GetById(this.delete).subscribe(( res: any) => {

        this.objpost = res;
        console.log(this.objpost);
     });
      console.log(this.ActivateRouter.snapshot.params['id' ] );

    }
  }

  Delete(){
    this.postService.DeletePost(this.objpost).subscribe(res=>{
      console.log(res);
      if(res){
        this.notification.showDelete("","");
        this.router.navigate(['/Post/View']);
      }

    },er=>{
      this.notification.showError("","");
    })
  }

}
