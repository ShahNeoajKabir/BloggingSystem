import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Status } from '../../../Common/Enum';
import { Utility } from '../../../Common/Utility';
import { Categories } from '../../../Model/Categories';
import { CategoriesService } from '../../../Services/Categories/categories.service';
import { NotificationService } from '../../../Services/Notification/notification.service';

@Component({
  selector: 'app-add-categories',
  templateUrl: './add-categories.component.html',
  styleUrls: ['./add-categories.component.scss']
})
export class AddCategoriesComponent implements OnInit {
  public objcategories:Categories=new Categories();
  public editcategories:Categories=new Categories();
  public lstStatus:any;

  constructor(private Categoriesservice:CategoriesService, private router:Router,
    private ActivateRouter:ActivatedRoute,
    private notification:NotificationService,
    private utility:Utility
    ) { }

  ngOnInit(): void {
    this.lstStatus=this.utility.enumToArray(Status);
    if (this.ActivateRouter.snapshot.params['id'] !== undefined) {

      this.editcategories.CategoriesId = this.ActivateRouter.snapshot.params['id' ];
      this.Categoriesservice.GetById(this.editcategories).subscribe(( res: any) => {

        this.objcategories = res;
        console.log(this.objcategories);
     });
      console.log(this.ActivateRouter.snapshot.params['id' ] );

    }

  }

  AddCategories(){
    if (this.objcategories.CategoriesId > 0 ) {
      this.Categoriesservice.UpdateCategories(this.objcategories).subscribe(res => {
        console.log(res);
        if(res){
          this.notification.showUpdate("","");
          this.router.navigate(['/Categories/View']);
        }
      }, er=>{
        this.notification.showError("","");
      });
    } else {
      this.Categoriesservice.AddCategories(this.objcategories).subscribe(res => {
        
        console.log(res);
        if(res){
          this.router.navigate(['/Categories/View']);
          this.notification.showSuccess("Successfully","Added");
        }
      },er=>{
        this.notification.showError("","");
      } );
    }
  }

}
