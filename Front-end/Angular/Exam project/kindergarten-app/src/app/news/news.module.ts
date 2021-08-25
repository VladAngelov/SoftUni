import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewsComponent } from './list/news.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { NewsRoutingModule } from './news-routnig.model';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    NewsComponent,
    CreateComponent,
    EditComponent
  ],
  imports: [
    CommonModule,
    NewsRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    EditComponent,
    CreateComponent,
    NewsComponent
  ]
})

export class NewsModule { }
