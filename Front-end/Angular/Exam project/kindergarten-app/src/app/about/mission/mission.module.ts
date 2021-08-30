import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormsModule,
  ReactiveFormsModule
} from '@angular/forms';

import { MissionComponent } from './list/mission.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { MissionRoutingModule } from './mission-routing.model';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [
    MissionComponent,
    CreateComponent,
    EditComponent
  ],
  imports: [
    CommonModule,
    MissionRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    EditComponent,
    CreateComponent,
    MissionComponent
  ]
})
export class MissionModule { }
