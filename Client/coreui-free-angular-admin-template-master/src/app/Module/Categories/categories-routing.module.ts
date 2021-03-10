
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ToastrModule } from 'ngx-toastr';
import { AddCategoriesComponent } from './add-categories/add-categories.component';
import { DeleteCategoriesComponent } from './delete-categories/delete-categories.component';
import { ListCategoriesComponent } from './list-categories/list-categories.component';

const routes: Routes = [{ path: 'AddCategories', component: AddCategoriesComponent },
{ path: 'View', component: ListCategoriesComponent },
{ path: ':id/edit', component: AddCategoriesComponent },
{ path: ':id/delete', component: DeleteCategoriesComponent },










];

@NgModule({
  imports: [RouterModule.forChild(routes),ToastrModule.forRoot()],
  exports: [RouterModule]
})
export class CategoriesRoutingModule { }