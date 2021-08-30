import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormsModule,
  ReactiveFormsModule
} from '@angular/forms';

import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { HistoryComponent } from './list/history.component';
import { HistoryRoutingModule } from './history-routing.model';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [
    HistoryComponent,
    CreateComponent,
    EditComponent
  ],
  imports: [
    CommonModule,
    HistoryRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    EditComponent,
    CreateComponent,
    HistoryComponent
  ]
})

export class HistoryModule { }
