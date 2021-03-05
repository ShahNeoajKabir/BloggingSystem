import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class RoleService {
  url="http://localhost:50604/api/Role/";

  constructor(private httpclient:HttpClient) { }

  AddRole(User:any){
    return this.httpclient.post(this.url+"AddRole",User);
  }

  DeleteRole(User:any){
    return this.httpclient.post(this.url+"DeleteRole",User);
  }

  UpdateRole(User:any){
    return this.httpclient.post(this.url+"UpdateRole",User);
  }


  GetById(User:any){
    return this.httpclient.post(this.url+"GetById",User);
  }

  GetAll(){
    return this.httpclient.get(this.url+"GetAll");
  }
}
