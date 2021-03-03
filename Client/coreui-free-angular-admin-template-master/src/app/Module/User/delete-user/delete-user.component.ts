import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { User } from '../../../Model/User';
import { UserService } from '../../../Services/User/user.service';

@Component({
  selector: 'app-delete-user',
  templateUrl: './delete-user.component.html',
  styleUrls: ['./delete-user.component.scss']
})
export class DeleteUserComponent implements OnInit {
  public lstuser:User=new User();
  public deleteuser:User=new User();

  public userid:any;

  constructor(private userservice:UserService, private router:Router, private httpclient:HttpClient,private ActivateRouter:ActivatedRoute) { }

  ngOnInit(): void {
    if (this.ActivateRouter.snapshot.params['id'] !== undefined) {

      this.deleteuser.UserId = this.ActivateRouter.snapshot.params['id' ];
      this.userservice.GetById(this.deleteuser).subscribe(( res: any) => {

        this.lstuser = res;
        console.log(res);
     });
      console.log(this.ActivateRouter.snapshot.params['id' ] );

    }
  }

  DeleteUser(){
    this.userservice.DeleteUser(this.lstuser).subscribe((res:any)=>{
      console.log(res)
    })
  }

}
