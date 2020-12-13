import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PostComponent } from './post/post.component';
import { CreateComponent } from './post/create/create.component';
import { HomeRoutingModule } from './home-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeService } from './home.service';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    PostComponent,
    CreateComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    HomeService
  ]
})

export class HomeModule { }
