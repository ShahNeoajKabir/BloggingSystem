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
    return this.httpclient.post(this.url+"GetAllStuff","");
  }

  public GetAllUser(){
    return this.httpclient.get(this.url+"GetAllUser");
  }

  public GetAllUnAssignUser(){
    return this.httpclient.get(this.url+"GetAllUnAssignUser");
  }


  public UpdateUser(User:any){
    return this.httpclient.post(this.url+"UpdateUser",User);
  }

  public SerchBy(User:any){
    return this.httpclient.post(this.url+"SerchBy",User);
  }
  
  public GetByID(User:any){
    return this.httpclient.post(this.url+"GetByID",User);
  }

  public DeleteUser(User:any){
    return this.httpclient.post(this.url+"DeleteUser",User);
  }
}
