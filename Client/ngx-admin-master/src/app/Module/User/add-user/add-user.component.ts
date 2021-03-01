import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Status, UserType } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { User } from '../../../Model/User';
import { UserService } from '../../../Services/User/user.service';

@Component({
  selector: 'ngx-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.scss']
})
export class AddUserComponent implements OnInit {
  public objuser:User=new User();
  public lstStatus:any;
  public lstusertype:any; 

  constructor(private userservice:UserService, private router:Router, private utility:Utility) { }

  ngOnInit(): void {
    this.lstStatus=this.utility.enumToArray(Status);
    this.lstusertype=this.utility.enumToArray(UserType);
  }

}
