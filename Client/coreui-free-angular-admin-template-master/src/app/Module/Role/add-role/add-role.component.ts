import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Role } from '../../../Model/Role';
import { NotificationService } from '../../../Services/Notification/notification.service';
import { RoleService } from '../../../Services/Role/role.service';

@Component({
  selector: 'app-add-role',
  templateUrl: './add-role.component.html',
  styleUrls: ['./add-role.component.scss']
})
export class AddRoleComponent implements OnInit {
  public objRole:Role=new Role();
  public editrole:Role=new Role();
  public lstStatus:any;

  constructor(private roleservice:RoleService, private router:Router, private utility:Utility, private ActivateRouter:ActivatedRoute , private notification:NotificationService) { }

  ngOnInit(): void {
    this.lstStatus=this.utility.enumToArray(Status);
    if (this.ActivateRouter.snapshot.params['id'] !== undefined) {

      this.editrole.RoleId = this.ActivateRouter.snapshot.params['id' ];
      this.roleservice.GetById(this.editrole).subscribe(( res: any) => {

        this.objRole = res;
        console.log(this.objRole);
     });
      console.log(this.ActivateRouter.snapshot.params['id' ] );

    }
  }


  AddRole(){
    if (this.objRole.RoleId > 0 ) {
      this.roleservice.UpdateRole(this.objRole).subscribe(res => {
        console.log(res);
        if(res){
          
        this.notification.showUpdate("","");
          this.router.navigate(['/Role/ViewRole']);
        }
      }, er=>{
        this.notification.showError("","");
          this.router.navigate(['/Role/AddRole']);
      });
    } else {
      this.roleservice.AddRole(this.objRole).subscribe(res => {
        
        console.log(res);
        if(res){
          this.router.navigate(['/Role/ViewRole']);
          this.notification.showSuccess("Successfully","Added");
        }
      },er=>{
        this.notification.showError("","");
          this.router.navigate(['/Role/AddRole']);
      } );
    }
  }

}
