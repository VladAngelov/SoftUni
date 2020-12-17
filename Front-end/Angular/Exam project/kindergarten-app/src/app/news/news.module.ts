import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NewsComponent } from './list/news.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { NewsRoutingModule } from './news-routnig.model';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NewsService } from './news.service';

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
  providers: [
    NewsService
  ],
  exports: [
    EditComponent,
    CreateComponent,
    NewsComponent
  ]
})

export class NewsModule { }
