import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  url="http://localhost:50604/api/User/";

  constructor(private httpclient:HttpClient) { }

  public AddUser(User:any){
    return this.httpclient.post(this.url+"AddUser",User);
  }

  public GetAllStuff(){
    return this.httpclient.get(this.url+"GetAllStuff");
  }

  public GetAllUser(){
    return this.httpclient.get(this.url+"GetAllUser");
  }
}
