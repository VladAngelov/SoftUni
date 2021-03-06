import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CreateComponent } from './post/create/create.component';
import { HomeRoutingModule } from './home-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HomeService } from './home.service';
import { SharedModule } from '../shared/shared.module';
import { HomeComponent } from './home.component';
import { EditComponent } from './post/edit/edit.component';

@NgModule({
  declarations: [
    HomeComponent,
    CreateComponent,
    EditComponent
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
  ],
  exports: [
    EditComponent,
    CreateComponent,
    HomeComponent
  ]
})

export class HomeModule { }
