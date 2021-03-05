import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserRole } from '../../../Model/UserRole';
import { UserRoleService } from '../../../Services/UserRole/user-role.service';

@Component({
  selector: 'app-list-user-role',
  templateUrl: './list-user-role.component.html',
  styleUrls: ['./list-user-role.component.scss']
})
export class ListUserRoleComponent implements OnInit {

  public lstuserrole:UserRole[]=new Array<UserRole>();

  constructor(private userroleservice:UserRoleService , private router:Router ) { }

  ngOnInit(): void {
    this.userroleservice.GetAll().subscribe((res:any)=>{
      this.lstuserrole=res;
      console.log(res);
    })
  }

}
