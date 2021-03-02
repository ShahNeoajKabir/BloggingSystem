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
  ImageBaseData:string | ArrayBuffer=null;
  imageError: string;
  isImageSaved: boolean;
  cardImageBase64: string;
  

  constructor(private userservice:UserService, private router:Router, private utility:Utility) { }

  ngOnInit(): void {
    this.lstStatus=this.utility.enumToArray(Status);
    this.lstusertype=this.utility.enumToArray(UserType);
  }
  AddUser(){
    this.userservice.AddUser(this.objuser).subscribe(res=>{
      console.log(res);
    });
  }

  handleFileInput(files: FileList) {
    let me = this;
    let file = files[0];
    let reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
      console.log(reader.result);
      me.ImageBaseData=reader.result;
    };
    reader.onerror = function (error) {
      console.log('Error: ', error);
    };
 }
  btnUpload(){
    
    if(this.ImageBaseData==null){
      alert("Please select file");
    }else{     
      
      this.objuser.Image=this.ImageBaseData.toString();
      
      
    }

}
}
