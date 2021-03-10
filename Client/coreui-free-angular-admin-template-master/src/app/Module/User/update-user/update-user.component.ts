import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { VmUsers } from '../../../Model/User';
import { NotificationService } from '../../../Services/Notification/notification.service';
import { UserService } from '../../../Services/User/user.service';

@Component({
  selector: 'app-update-user',
  templateUrl: './update-user.component.html',
  styleUrls: ['./update-user.component.scss']
})
export class UpdateUserComponent implements OnInit {

  public objuser:VmUsers=new VmUsers();
  public edituser:VmUsers=new VmUsers();

  public userid:any;

  constructor(private userservice:UserService, private router:Router, private httpclient:HttpClient,private ActivateRouter:ActivatedRoute, private notification:NotificationService) { }

  ngOnInit(): void {
    if (this.ActivateRouter.snapshot.params['id'] !== undefined) {

      this.edituser.UserId = this.ActivateRouter.snapshot.params['id' ];
      this.userservice.SerchBy(this.edituser).subscribe(( res: any) => {

        this.objuser = res;
        console.log(res);
     });
      console.log(this.ActivateRouter.snapshot.params['id' ] );

    }
  }

  AddUser(){
    this.userservice.UpdateUser(this.objuser).subscribe(res=>{
      console.log(res);
      if(res){
        this.notification.showUpdate("","");
        this.router.navigate(['/User/ViewStuff']);
      }
    },er=>{
      this.notification.showError("","");
    })
  }

}
