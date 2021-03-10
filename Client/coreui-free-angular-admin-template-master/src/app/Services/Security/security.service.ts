import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SecurityService {
  url="http://localhost:50604/api/Security/";

  constructor(private httpclient:HttpClient) { }

  Login(vmlogin:any){
     return this.httpclient.post(this.url+"Login",vmlogin);
  }
}
