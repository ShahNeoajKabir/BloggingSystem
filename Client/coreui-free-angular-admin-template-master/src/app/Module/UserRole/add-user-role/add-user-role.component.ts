import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { UserRole } from '../../../Model/UserRole';
import { RoleService } from '../../../Services/Role/role.service';
import { UserService } from '../../../Services/User/user.service';
import { UserRoleService } from '../../../Services/UserRole/user-role.service';

@Component({
  selector: 'app-add-user-role',
  templateUrl: './add-user-role.component.html',
  styleUrls: ['./add-user-role.component.scss']
})
export class AddUserRoleComponent implements OnInit {

  public objuserrole:UserRole=new UserRole();
  public edituserrole:UserRole=new UserRole();
  public lstuser:any;
  public lstrole:any;
  public lstStatus:any;


  constructor(private userroleservice:UserRoleService,
     private userservice:UserService,
      private roleservice:RoleService, 
      private router:Router ,
       private activatedroute:ActivatedRoute,
       private utility:Utility
       
       ) { }

  ngOnInit(): void {
    this.lstStatus=this.utility.enumToArray(Status);

    this.roleservice.GetAll().subscribe((res:any)=>{
      this.lstrole=res;
      console.log(this.lstrole);
    });

    this.userservice.GetAllUnAssignUser().subscribe((res:any)=>{
      this.lstuser=res;
      console.log(this.lstuser);
    });
    if (this.activatedroute.snapshot.params[ 'id'] !== undefined) {
      this.objuserrole.UserId = this.activatedroute.snapshot.params[ 'id'];
      console.log(this.activatedroute.snapshot.params[ 'id']);
    }
  }


  AddUserRole(){
    this.userroleservice.AddUserRole(this.objuserrole).subscribe(res=>{
      console.log(res);

      
    })
  }

}
