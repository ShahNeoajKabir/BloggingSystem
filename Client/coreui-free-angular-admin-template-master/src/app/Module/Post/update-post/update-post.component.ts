import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Post } from '../../../Model/Post';
import { CategoriesService } from '../../../Services/Categories/categories.service';
import { NotificationService } from '../../../Services/Notification/notification.service';
import { PostService } from '../../../Services/Post/post.service';

@Component({
  selector: 'app-update-post',
  templateUrl: './update-post.component.html',
  styleUrls: ['./update-post.component.scss']
})
export class UpdatePostComponent implements OnInit {
  public objpost:Post=new Post();
  public edit:Post=new Post();

  public lstcategories:any;
  public lstStatus:any;
  ImageBaseData:string | ArrayBuffer=null;
  imageError: string;
  isImageSaved: boolean;
  cardImageBase64: string;
  constructor(
    private postService:PostService ,
    private categorieservice:CategoriesService,
    private router:Router,
    private notification:NotificationService,
    private utility:Utility,
    private ActivateRouter:ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.lstStatus=this.utility.enumToArray(Status);

    this.categorieservice.GetAll().subscribe((res:any)=>{
      this.lstcategories=res;
      console.log(this.lstcategories);

    })
    if (this.ActivateRouter.snapshot.params['id'] !== undefined) {

      this.edit.PostId = this.ActivateRouter.snapshot.params['id' ];
      this.postService.GetById(this.edit).subscribe(( res: any) => {

        this.objpost = res;
        console.log(this.objpost);
     });
      console.log(this.ActivateRouter.snapshot.params['id' ] );

    }
  }


  Update(){
    this.postService.UpdatePost(this.objpost).subscribe(res=>{
      console.log(res);
      if(res){
        this.notification.showUpdate("","");
        this.router.navigate(['/Post/View']);
      }

    },er=>{
      this.notification.showError("","");
    })
  }

}
