import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Role } from '../../../Model/Role';
import { RoleService } from '../../../Services/Role/role.service';

@Component({
  selector: 'app-list-role',
  templateUrl: './list-role.component.html',
  styleUrls: ['./list-role.component.scss']
})
export class ListRoleComponent implements OnInit {
  public lstRole:Role[]=new Array<Role>();

  constructor(private roleservice:RoleService , private router:Router ) { }

  ngOnInit(): void {
    this.roleservice.GetAll().subscribe((res:any)=>{
      this.lstRole=res;
      console.log(this.lstRole);

    })
  }

}
