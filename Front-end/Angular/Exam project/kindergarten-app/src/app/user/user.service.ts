import { Injectable } from '@angular/core';
import { AuthenticationService } from '../core/authentication.service';
import { StorageService } from '../core/storage.service';

@Injectable()

export class UserService {

  isLogged = false;

  constructor(
    private authService: AuthenticationService,
    private storage: StorageService
  ) {
    this.isLogged = this.storage.getItem('isLogged');
  }

  register(email: string, password: string): void {
    this.authService.SignUp(email, password);
  }

  login(email: string, password: string): void {
    this.authService.SignIn(email, password);
  }

  logout(): void {
    this.authService.LogOut();
  }
}
