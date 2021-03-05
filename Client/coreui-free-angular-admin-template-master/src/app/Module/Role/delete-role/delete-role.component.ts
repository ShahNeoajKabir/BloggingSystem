import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Role } from '../../../Model/Role';
import { RoleService } from '../../../Services/Role/role.service';

@Component({
  selector: 'app-delete-role',
  templateUrl: './delete-role.component.html',
  styleUrls: ['./delete-role.component.scss']
})
export class DeleteRoleComponent implements OnInit {
  public objRole:Role = new Role();
  public deleteerole:Role=new Role();

  constructor(private roleservice:RoleService, private router:Router , private ActivateRouter:ActivatedRoute) { }

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
        this.router.navigate(['/Role/ViewRole']);
      }

    })
  }

}
