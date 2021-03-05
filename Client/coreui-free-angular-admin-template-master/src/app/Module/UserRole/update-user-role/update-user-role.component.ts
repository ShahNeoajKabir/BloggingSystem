import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { UserRole } from '../../../Model/UserRole';
import { RoleService } from '../../../Services/Role/role.service';
import { UserService } from '../../../Services/User/user.service';
import { UserRoleService } from '../../../Services/UserRole/user-role.service';

@Component({
  selector: 'app-update-user-role',
  templateUrl: './update-user-role.component.html',
  styleUrls: ['./update-user-role.component.scss']
})
export class UpdateUserRoleComponent implements OnInit {
  public objuserrole:UserRole=new UserRole();
  public edituserrole:UserRole=new UserRole();
  public lstuser:any;
  public lstrole:any;
  public lstStatus:any;

  constructor(
    private userroleservice:UserRoleService,
    private userservice:UserService,
    private utility:Utility ,
    private activatedroute:ActivatedRoute,
    private router:Router,
    private roleservice:RoleService
        ) { }

  ngOnInit(): void {
    this.lstStatus=this.utility.enumToArray(Status);

    this.userservice.GetAllStuff().subscribe((res:any)=>{
      this.lstuser=res;
      console.log(this.lstuser);
    });
    this.roleservice.GetAll().subscribe((res:any)=>{
      this.lstrole=res;
      console.log(this.lstrole);
    });

    if (this.activatedroute.snapshot.params[ 'id'] !== undefined) {
      this.edituserrole.UserRoleId = this.activatedroute.snapshot.params[ 'id'];
      this.userroleservice.GetById(this.edituserrole).subscribe((res: any) => {
        this.objuserrole = res;
        console.log(this.objuserrole);
      });
      console.log(this.activatedroute.snapshot.params[ 'id']);
    }
  }

  UpdateUserRole(){
    this.userroleservice.UpdateUserRole(this.objuserrole).subscribe(res=>{
      console.log(res);
      if(res){
        this.router.navigate(['/UserRole/View']);
      }
    })

  }

}
