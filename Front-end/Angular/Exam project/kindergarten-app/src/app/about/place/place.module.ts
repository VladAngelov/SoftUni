import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PlaceComponent } from './list/place.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PlaceService } from './place.service';
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
  providers: [
    PlaceService
  ],
  exports: [
    EditComponent,
    CreateComponent,
    PlaceComponent
  ]
})
export class PlaceModule { }
