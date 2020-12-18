import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import { DetailComponent } from './detail/detail.component';
import { TeachersRoutingModule } from './teachers-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TeachersService } from './teachers.service';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';

@NgModule({
  declarations: [
    ListComponent,
    DetailComponent,
    CreateComponent,
    EditComponent,
  ],
  imports: [
    CommonModule,
    TeachersRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    TeachersService
  ],
  exports: [
    EditComponent,
    CreateComponent,
    ListComponent
  ]
})

export class TeachersModule { }
