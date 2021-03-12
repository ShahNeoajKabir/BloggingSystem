import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
  url="http://localhost:50604/api/Categories/";


  constructor(private httpclient:HttpClient) { }

  public AddCategories(Categories:any){
    return this.httpclient.post(this.url+"AddCategories",Categories);
  }


  public UpdateCategories(Categories:any){
    return this.httpclient.post(this.url+"UpdateCategories",Categories)
  }

  public DeleteCategories(Categories:any){
    return this.httpclient.post(this.url+"DeleteCategories",Categories)
  }

  public GetById(Categories:any){
    return this.httpclient.post(this.url+"GetById",Categories)
  }


  public GetAll(){
    return this.httpclient.get(this.url+"GetAll")
  }
}
