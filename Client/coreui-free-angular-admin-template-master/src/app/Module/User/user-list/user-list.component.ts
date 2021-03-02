import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../../../Model/User';
import { UserService } from '../../../Services/User/user.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss']
})
export class UserListComponent implements OnInit {

  public lstuser:User[]=new Array<User>();

  constructor(private userservice:UserService, private router:Router) { }

  ngOnInit(): void {
    this.userservice.GetAllUser().subscribe((res:any)=>{
      this.lstuser=res;
      console.log(res);
    })
  }

}
