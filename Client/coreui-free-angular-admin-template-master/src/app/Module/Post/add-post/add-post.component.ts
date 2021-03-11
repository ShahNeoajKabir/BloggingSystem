import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Post } from '../../../Model/Post';
import { CategoriesService } from '../../../Services/Categories/categories.service';
import { NotificationService } from '../../../Services/Notification/notification.service';
import { PostService } from '../../../Services/Post/post.service';

@Component({
  selector: 'app-add-post',
  templateUrl: './add-post.component.html',
  styleUrls: ['./add-post.component.scss']
})
export class AddPostComponent implements OnInit {
  public objpost:Post=new Post();
  public lstcategories:any;
  ImageBaseData:string | ArrayBuffer=null;
  imageError: string;
  isImageSaved: boolean;
  cardImageBase64: string;


  constructor(private postService:PostService ,
    private categorieservice:CategoriesService,
    private router:Router,
    private notification:NotificationService
    ) { }

  ngOnInit(): void {
    this.categorieservice.GetAll().subscribe((res:any)=>{
      this.lstcategories=res;
      console.log(this.lstcategories);
    })
  }

  AddPost(){
    this.postService.AddPost(this.objpost).subscribe(res=>{
      if(res){
        this.notification.showSuccess("","");
        this.router.navigate(['/Post/View']);
      }
    }, er=>{
      this.notification.showError("","");
    })

  }

  handleFileInput(files: FileList) {
    let me = this;
    let file = files[0];
    let reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
      console.log(reader.result);
      me.ImageBaseData=reader.result;
    };
    reader.onerror = function (error) {
      console.log('Error: ', error);
    };
 }
  btnUpload(){
    
    if(this.ImageBaseData==null){
      alert("Please select file");
    }else{     
      
      this.objpost.Image=this.ImageBaseData.toString();
      
      
    }

}

}
