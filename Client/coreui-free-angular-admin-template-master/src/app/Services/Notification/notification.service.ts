import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  constructor(private toastr: ToastrService) { }

  showSuccess(message, title){
    this.toastr.success("Data Added successfully!!", "Successfull");
}

showUpdate(message, title){
  this.toastr.success("Data Update successfully!!", "Updated");
}

showError(message, title){
    this.toastr.error("Something is wrong !! Please Try Again !!", "Error Occure")
}

showInfo(message, title){
    this.toastr.info(message, title)
}

showDelete(message, title){
    this.toastr.warning("Data Remove successfully!!", "Deleted")
}

LoginFailed(message, title){
  this.toastr.error("Email or Password incorrect", "Error!!")
}
 


}