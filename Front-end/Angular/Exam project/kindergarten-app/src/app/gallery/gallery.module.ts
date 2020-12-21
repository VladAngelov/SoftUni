import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { GalleryComponent } from './list/gallery.component';
import { CreateComponent } from './create/create.component';
import { GalleryRoutingModule } from './gallery-routing.model';
import { SharedModule } from '../shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GalleryService } from './gallery.service';

@NgModule({
  declarations: [
    GalleryComponent,
    CreateComponent

  ],
  imports: [
    CommonModule,
    GalleryRoutingModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    GalleryService
  ],
  exports: [
    CreateComponent,
    GalleryComponent
  ]
})
export class GalleryModule { }
