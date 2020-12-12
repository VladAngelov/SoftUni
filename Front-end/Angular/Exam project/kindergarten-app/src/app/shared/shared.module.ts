import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoaderComponent } from './loader/loader.component';
import { IsEmptyDirective } from './is-empty.directive';

@NgModule({
  declarations: [
    LoaderComponent,
    IsEmptyDirective
  ],
  imports: [
    CommonModule
  ],
  exports: [
    LoaderComponent,
    IsEmptyDirective
  ]
})

export class SharedModule { }
