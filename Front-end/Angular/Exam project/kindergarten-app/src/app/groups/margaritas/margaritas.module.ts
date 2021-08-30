import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormsModule,
  ReactiveFormsModule
} from '@angular/forms';

import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { MargaritasComponent } from './list/margaritas.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { MargaritasRoutingModule } from './margaritas-routing.model';

@NgModule({
  declarations: [
    MargaritasComponent,
    CreateComponent,
    EditComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    MargaritasRoutingModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    EditComponent,
    CreateComponent,
    MargaritasComponent
  ]
})

export class MargaritasModule { }
