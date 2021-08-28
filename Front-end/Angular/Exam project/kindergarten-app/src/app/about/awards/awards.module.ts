import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormsModule,
  ReactiveFormsModule
} from '@angular/forms';

import { AwardsComponent } from './list/awards.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { AwardsRoutingModule } from './awards-routing.model';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [
    AwardsComponent,
    CreateComponent,
    EditComponent
  ],
  imports: [
    CommonModule,
    AwardsRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    EditComponent,
    CreateComponent,
    AwardsComponent
  ]
})

export class AwardsModule { }
