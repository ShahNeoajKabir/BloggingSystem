import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Categories } from '../../../Model/Categories';
import { CategoriesService } from '../../../Services/Categories/categories.service';
import { NotificationService } from '../../../Services/Notification/notification.service';

@Component({
  selector: 'app-delete-categories',
  templateUrl: './delete-categories.component.html',
  styleUrls: ['./delete-categories.component.scss']
})
export class DeleteCategoriesComponent implements OnInit {
  public objCategories:Categories=new Categories();
  public dletecategories:Categories=new Categories();


  constructor(private categoriesservice:CategoriesService,
    private router:Router,
    private ActivateRouter:ActivatedRoute,
    private notification:NotificationService
    ) { }

  ngOnInit(): void {
    if (this.ActivateRouter.snapshot.params['id'] !== undefined) {

      this.dletecategories.CategoriesId = this.ActivateRouter.snapshot.params['id' ];
      this.categoriesservice.GetById(this.dletecategories).subscribe(( res: any) => {

        this.objCategories = res;
        console.log(this.objCategories);
     });
      console.log(this.ActivateRouter.snapshot.params['id' ] );

    }
  }


  Delete(){
    this.categoriesservice.DeleteCategories(this.objCategories).subscribe(res=>{
      if(res){
        this.notification.showDelete("","");
        this.router.navigate(['Categories/View']);
      }
    }, er=>{
      this.notification.showError("","");
    })
  }



}
