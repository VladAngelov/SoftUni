import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { RouterModule } from '@angular/router';
import { storageServiceProvider } from './storage.service';
import { AccessGuard } from './guards/access.guard';
import { AuthenticationService } from './authentication.service';

@NgModule({
  declarations: [
    HeaderComponent,
    FooterComponent
  ],
  imports: [
    CommonModule,
    RouterModule
  ],
  providers: [
    storageServiceProvider,
    AccessGuard,
    AuthenticationService
  ],
  exports: [
    HeaderComponent,
    FooterComponent]
})
export class CoreModule { }
