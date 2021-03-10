import { Component, OnInit } from '@angular/core';
import { Categories } from '../../../Model/Categories';
import { CategoriesService } from '../../../Services/Categories/categories.service';

@Component({
  selector: 'app-list-categories',
  templateUrl: './list-categories.component.html',
  styleUrls: ['./list-categories.component.scss']
})
export class ListCategoriesComponent implements OnInit {

  public lstcategories:Categories[]=new Array<Categories>();

  constructor(private categoriesservice:CategoriesService) { }

  ngOnInit(): void {
    this.categoriesservice.GetAll().subscribe((res:any)=>{
      this.lstcategories=res;
      console.log(this.lstcategories);
    })
  }

}
