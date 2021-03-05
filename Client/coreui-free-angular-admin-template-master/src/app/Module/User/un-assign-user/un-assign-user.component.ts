import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../../../Model/User';
import { UserService } from '../../../Services/User/user.service';

@Component({
  selector: 'app-un-assign-user',
  templateUrl: './un-assign-user.component.html',
  styleUrls: ['./un-assign-user.component.scss']
})
export class UnAssignUserComponent implements OnInit {

  public lstuser:User[]=new Array<User>();

  constructor(private userservice:UserService , private route:Router) { }

  ngOnInit(): void {
    this.userservice.GetAllUnAssignUser().subscribe((res:any)=>{
      this.lstuser=res;
      console.log(this.lstuser);
    })
  }

}
