import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormsModule,
  ReactiveFormsModule
} from '@angular/forms';

import { ProjectsComponent } from './list/projects.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { ProjectRoutingModule } from './project-routing.model';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  declarations: [
    ProjectsComponent,
    CreateComponent,
    EditComponent
  ],
  imports: [
    CommonModule,
    ProjectRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    EditComponent,
    CreateComponent,
    ProjectsComponent
  ]
})

export class ProjectModule { }
