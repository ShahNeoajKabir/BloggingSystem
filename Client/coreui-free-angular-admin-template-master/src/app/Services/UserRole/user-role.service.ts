import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserRoleService {

  url="http://localhost:50604/api/UserRole/";

  constructor(private httpclient:HttpClient) { }



  public AddUserRole(Userrole:any){
    return this.httpclient.post(this.url+"AddUserRole", Userrole);
  }

  public GetAll(){
    return this.httpclient.get(this.url+"GetAll");
  }

  public UpdateUserRole(Userrole:any){
    return this.httpclient.post(this.url+"UpdateUserRole", Userrole);
  }

  public GetById(Userrole:any){
    return this.httpclient.post(this.url+"GetById", Userrole);
  }

  public DeleteUserRole(Userrole:any){
    return this.httpclient.post(this.url+"DeleteUserRole", Userrole);
  }
}
