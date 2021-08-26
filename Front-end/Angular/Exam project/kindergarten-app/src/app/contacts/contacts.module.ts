import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {
  FormsModule,
  ReactiveFormsModule
} from '@angular/forms';

import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { ContactsComponent } from './list/contacts.component';
import { ContactsRoutingModule } from './contacts-routing.model';
import { SharedModule } from '../shared/shared.module';
import { ContactsService } from '../_services/contacts/contacts.service';

@NgModule({
  declarations: [
    ContactsComponent,
    CreateComponent,
    EditComponent
  ],
  imports: [
    CommonModule,
    ContactsRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    ContactsService
  ],
  exports: [
    EditComponent,
    CreateComponent,
    ContactsComponent
  ]
})

export class ContactsModule { }
