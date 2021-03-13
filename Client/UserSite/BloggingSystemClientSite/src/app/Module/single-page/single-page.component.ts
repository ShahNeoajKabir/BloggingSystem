import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/Model/Post';
import { Comment } from 'src/app/Model/Comments';

import { IndexService } from 'src/app/Service/Index/index.service';
import { CategoriesService } from 'src/app/Service/Categories/Categories.service';
import { ActivatedRoute, Router } from '@angular/router';


@Component({
  selector: 'app-single-page',
  templateUrl: './single-page.component.html',
  styleUrls: ['./single-page.component.css']
})
export class SinglePageComponent implements OnInit {
  public objpost:Post=new Post();
  public edit:Post=new Post();
  public objcomment:Comment=new Comment();
  public lstcomment:Comment[]=new Array<Comment>();

  public lstcategories:any;
  public lstStatus:any;
  ImageBaseData:string | ArrayBuffer=null;
  imageError: string;
  isImageSaved: boolean;
  cardImageBase64: string;
  constructor(
    private postService:IndexService ,
    private categorieservice:CategoriesService,
    private router:Router,
    private ActivateRouter:ActivatedRoute
  ) { }

  ngOnInit(): void {

    this.categorieservice.GetAll().subscribe((res:any)=>{
      this.lstcategories=res;
      console.log(this.lstcategories);

    });

    this.postService.GetComment().subscribe((res:any)=>{
      this.lstcomment=res;
      console.log(this.lstcomment);

    });
    if (this.ActivateRouter.snapshot.params['id'] !== undefined) {

      this.edit.PostId = this.ActivateRouter.snapshot.params['id' ];
      this.postService.ViewById(this.edit).subscribe(( res: any) => {

        this.objpost = res;
        console.log(this.objpost);
     });
      console.log(this.ActivateRouter.snapshot.params['id' ] );

    }
  }

  AddComment(){
    this.objcomment.PostId=this.objpost.PostId;
    this.postService.AddComment(this.objcomment).subscribe(res=>{
      if(res){
        this.router.navigate(['/View']);
      }
    })
  }

}
