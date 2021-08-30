import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormsModule,
  ReactiveFormsModule
} from '@angular/forms';

import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { SchoolsComponent } from './list/schools.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { SchoolsRoutingModule } from './schools-routing.model';

@NgModule({
  declarations: [
    SchoolsComponent,
    CreateComponent,
    EditComponent
  ],
  imports: [
    CommonModule,
    SchoolsRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    EditComponent,
    CreateComponent,
    SchoolsComponent
  ]
})
export class SchoolsModule { }
