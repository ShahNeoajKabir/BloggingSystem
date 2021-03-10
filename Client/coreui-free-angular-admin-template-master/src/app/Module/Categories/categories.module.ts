import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CategoriesService } from '../../Services/Categories/categories.service';
import { CategoriesRoutingModule } from './categories-routing.module';
import { AddCategoriesComponent } from './add-categories/add-categories.component';
import { ListCategoriesComponent } from './list-categories/list-categories.component';
import { DeleteCategoriesComponent } from './delete-categories/delete-categories.component';




@NgModule({
  declarations: [AddCategoriesComponent, ListCategoriesComponent, DeleteCategoriesComponent],
  imports: [
    CommonModule,
    CategoriesRoutingModule,
    FormsModule
  ],
  providers:[CategoriesService],
})
export class CategoriesModule { }