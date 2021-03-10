import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Role } from '../../../Model/Role';
import { NotificationService } from '../../../Services/Notification/notification.service';
import { RoleService } from '../../../Services/Role/role.service';

@Component({
  selector: 'app-delete-role',
  templateUrl: './delete-role.component.html',
  styleUrls: ['./delete-role.component.scss']
})
export class DeleteRoleComponent implements OnInit {
  public objRole:Role = new Role();
  public deleteerole:Role=new Role();

  constructor(private roleservice:RoleService, private router:Router , private ActivateRouter:ActivatedRoute , private notification:NotificationService) { }

  ngOnInit(): void {
    if (this.ActivateRouter.snapshot.params['id'] !== undefined) {

      this.deleteerole.RoleId = this.ActivateRouter.snapshot.params['id' ];
      this.roleservice.GetById(this.deleteerole).subscribe(( res: any) => {

        this.objRole = res;
        console.log(this.objRole);
     });
      console.log(this.ActivateRouter.snapshot.params['id' ] );

    }
  }

  Delete(){
    this.roleservice.DeleteRole(this.objRole).subscribe(res=>{
      console.log(res);
      if(res){
        this.notification.showDelete("","");
        this.router.navigate(['/Role/ViewRole']);
      }

    },er=>{
      this.notification.showError("","");
    })
  }

}
