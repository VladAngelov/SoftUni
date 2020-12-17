import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PuhComponent } from './list/puh.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { PuhRoutingModule } from './puh-routing.model';
import { SharedModule } from 'src/app/shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PuhService } from './puh.service';

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
  providers: [
    PuhService
  ],
  exports: [
    EditComponent,
    CreateComponent,
    PuhComponent
  ]
})

export class PuhModule { }
