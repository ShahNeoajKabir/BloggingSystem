import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  url="http://localhost:50604/api/Post/";


  constructor(private httpclient:HttpClient) { }

  public AddPost(post:any){
    return this.httpclient.post(this.url+"AddPost",post);

  }

  public UpdatePost(post:any){
    return this.httpclient.post(this.url+"UpdatePost",post);

  }
  public DeletePost(post:any){
    return this.httpclient.post(this.url+"DeletePost",post);

  }

  public GetById(post:any){
    return this.httpclient.post(this.url+"GetById",post);

  }
  public GetAll(){
    return this.httpclient.get(this.url+"GetAll");

  }
}
