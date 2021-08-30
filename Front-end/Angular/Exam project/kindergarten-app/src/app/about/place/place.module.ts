import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormsModule,
  ReactiveFormsModule
} from '@angular/forms';

import { PlaceComponent } from './list/place.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { PlaceRoutingModule } from './place-routing.model';

@NgModule({
  declarations: [
    PlaceComponent,
    CreateComponent,
    EditComponent
  ],
  imports: [
    CommonModule,
    PlaceRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    EditComponent,
    CreateComponent,
    PlaceComponent
  ]
})
export class PlaceModule { }
