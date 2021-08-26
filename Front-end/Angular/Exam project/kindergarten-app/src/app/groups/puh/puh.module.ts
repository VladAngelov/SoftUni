import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormsModule,
  ReactiveFormsModule
} from '@angular/forms';

import { PuhComponent } from './list/puh.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { PuhRoutingModule } from './puh-routing.model';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  declarations: [
    PuhComponent,
    CreateComponent,
    EditComponent
  ],
  imports: [
    CommonModule,
    PuhRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    EditComponent,
    CreateComponent,
    PuhComponent
  ]
})

export class PuhModule { }
