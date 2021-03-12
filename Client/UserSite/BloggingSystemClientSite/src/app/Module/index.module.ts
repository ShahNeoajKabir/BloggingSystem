import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import {IndexService} from '../Service/Index/index.service';
import {HomePageComponent} from './home-page/home-page.component';
import {SinglePageComponent} from './single-page/single-page.component';
import { IndexRoutingModule } from './index-routing.module';
import { LayoutComponent } from './layout/layout.component';





@NgModule({
  declarations: [HomePageComponent , SinglePageComponent, LayoutComponent
],
  imports: [
    CommonModule,
    IndexRoutingModule,
    FormsModule
  ],
  providers:[IndexService],
})
export class IndexModule { }