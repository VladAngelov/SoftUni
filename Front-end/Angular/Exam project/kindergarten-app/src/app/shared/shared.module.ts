import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoaderComponent } from './loader/loader.component';
import { IsEmptyDirective } from './is-empty.directive';
import { EmailValidatorDirective } from './email-validator.directive';

@NgModule({
  declarations: [
    LoaderComponent,
    IsEmptyDirective,
    EmailValidatorDirective
  ],
  imports: [
    CommonModule
  ],
  exports: [
    LoaderComponent,
    IsEmptyDirective,
    EmailValidatorDirective
  ]
})

export class SharedModule { }
