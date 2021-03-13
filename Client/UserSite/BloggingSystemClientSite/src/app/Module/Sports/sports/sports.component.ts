import { Component, OnInit } from '@angular/core';
import { Post } from 'src/app/Model/Post';
import { IndexService } from 'src/app/Service/Index/index.service';

@Component({
  selector: 'app-sports',
  templateUrl: './sports.component.html',
  styleUrls: ['./sports.component.css']
})
export class SportsComponent implements OnInit {
  public lstpost:Post[]=new Array<Post>();

  constructor( private indexservice:IndexService) { }

  ngOnInit(): void {
    this.indexservice.GetAllSports().subscribe((res:any)=>{
      this.lstpost=res;
      console.log(res);
    })
  }
}
