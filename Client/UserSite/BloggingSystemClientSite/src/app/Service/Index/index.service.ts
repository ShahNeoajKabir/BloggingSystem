import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class IndexService {
  url="http://localhost:50604/api/Post/";


  constructor(private httpclient:HttpClient) { }

  public AddPost(post:any){
    return this.httpclient.post(this.url+"AddPost",post);

  }

  public GetAll(){
    return this.httpclient.get(this.url+"GetAll");

  }
  public GetById(post:any){
    return this.httpclient.post(this.url+"GetById",post);

  }

  public ViewById(post:any){
    return this.httpclient.post(this.url+"ViewById",post);

  }
}
