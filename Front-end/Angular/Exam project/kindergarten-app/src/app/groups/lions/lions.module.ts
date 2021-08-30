import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormsModule,
  ReactiveFormsModule
} from '@angular/forms';

import { LionsComponent } from './list/lions.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { LionsRoutingModule } from './lions-routing.model';

@NgModule({
  declarations: [
    LionsComponent,
    CreateComponent,
    EditComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    LionsRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    EditComponent,
    CreateComponent,
    LionsComponent
  ]
})

export class LionsModule { }
