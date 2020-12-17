import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { MargaritasComponent } from './list/margaritas.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { MargaritasRoutingModule } from './margaritas-routing.model';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MargaritasService } from './margaritas.service';

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
  providers: [
    MargaritasService
  ],
  exports: [
    EditComponent,
    CreateComponent,
    MargaritasComponent
  ]
})

export class MargaritasModule { }
