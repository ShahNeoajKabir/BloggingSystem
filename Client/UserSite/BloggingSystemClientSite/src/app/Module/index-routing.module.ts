import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomePageComponent } from './home-page/home-page.component';
import { LayoutComponent } from './layout/layout.component';
import { SinglePageComponent } from './single-page/single-page.component';
import { SportsComponent } from './Sports/sports/sports.component';

const route: Routes =[

    { path: '', component: LayoutComponent ,
children:[
  { path: 'Home', component: HomePageComponent },
  { path: 'Sports', component: SportsComponent },

  { path: ':id/View', component: SinglePageComponent },




]

    }
]

@NgModule({
  declarations: [],
  imports: [RouterModule.forChild(route)],


  exports:[RouterModule]
})
export class IndexRoutingModule { }