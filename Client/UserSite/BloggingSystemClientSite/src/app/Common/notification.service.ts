import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr/toastr/toastr.service';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  private timeOut = 3000;
  constructor(private toastService: ToastrService) {
  }

  public success( text: string, title: string = 'Success', timeout?: number) {
    this.toastService.success(text, title, {
      timeOut : this.timeOut
    });
  }

  public warn(text: string, title: string= 'Waring', timeout?: number) {
    this.toastService.warning(text, title, {
      timeOut : this.timeOut
    });
  }

  public error(text: string, title: string = 'Error', timeout?: number) {
    this.toastService.error(text, title, {
      timeOut : this.timeOut
    });
  }

  public info( text: string, title: string= 'Info', timeout?: number) {
    this.toastService.info(text, title, {
      timeOut : this.timeOut
    });
  }

  public infoWithoutTimeLimit( text: string, title: string= 'Info') {
    this.toastService.info(text, title, {
      disableTimeOut: true,
      closeButton: true
    });
  }

  
}
