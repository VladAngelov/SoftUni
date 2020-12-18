import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { HistoryComponent } from './list/history.component';
import { HistoryRoutingModule } from './history-routing.model';
import { SharedModule } from 'src/app/shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HistoryService } from './history.service';

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
  providers: [
    HistoryService
  ],
  exports: [
    EditComponent,
    CreateComponent,
    HistoryComponent
  ]
})

export class HistoryModule { }
