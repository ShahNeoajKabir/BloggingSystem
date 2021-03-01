import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiConstant } from '../../Common/ApiConstant';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpclient:HttpClient) { }

  public AddUser(User:any){
    return this.httpclient.post(ApiConstant+"AddUser",User);
  }
}
