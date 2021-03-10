import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { User, VmUsers } from '../../../Model/User';
import { UserService } from '../../../Services/User/user.service';

@Component({
  selector: 'app-stuff-list',
  templateUrl: './stuff-list.component.html',
  styleUrls: ['./stuff-list.component.scss']
})
export class StuffListComponent implements OnInit {
  public lstuser:VmUsers[]=new Array<VmUsers>();

  constructor(private userservice:UserService , private router:Router) { }

  ngOnInit(): void {

    this.userservice.GetAllStuff().subscribe((res:any)=>{
      this.lstuser=res;
      console.log(this.lstuser);

    });
  }
  Edit(id: any) {

    console.log(id);
  }

}
