import { Component, OnInit } from '@angular/core';
import { IndexService } from 'src/app/Service/Index/index.service';
import {Post} from '../../Model/Post'

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {
  public lstpost:Post[]=new Array<Post>();

  constructor( private indexservice:IndexService) { }

  ngOnInit(): void {
    this.indexservice.GetAll().subscribe((res:any)=>{
      this.lstpost=res;
      console.log(res);
    })
  }

}
