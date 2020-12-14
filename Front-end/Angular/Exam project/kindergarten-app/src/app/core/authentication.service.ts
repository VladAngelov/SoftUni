import { Injectable } from '@angular/core';
import { AngularFireAuth } from "@angular/fire/auth";
import { Router } from '@angular/router';
import { emailValidatorBackend } from '../shared/validators';
import { StorageService } from './storage.service';

@Injectable()

export class AuthenticationService {

  constructor(
    private authenticationService: AngularFireAuth,
    private router: Router,
    private storage: StorageService
  ) {
  }

  // Sign up with email/password
  SignUp(email, password) {
    debugger;
    if (emailValidatorBackend(email)) {
      return this.authenticationService.createUserWithEmailAndPassword(email, password)
        .then(user => {
          const { user: { uid, email } } = user;
          localStorage.setItem('auth', JSON.stringify({ uid, email }));
          this.router.navigate(['/']);
          this.storage.setItem('isLogged', true);
        }).catch((error) => {
          console.log(error);
        })
    }
    window.alert('Неправилен имейл или парола!');
  }

  // Sign in with email/password
  SignIn(email, password) {
    return this.authenticationService.signInWithEmailAndPassword(email, password)
      .then(user => {
        const { user: { uid, email } } = user;
        localStorage.setItem('auth', JSON.stringify({ uid, email }));
        this.router.navigate(['/']);
        this.storage.setItem('isLogged', true);
        window.alert('Успешно логване!');
      }).catch(err => console.log(err));
  }

  // Logout
  LogOut() {
    this.authenticationService.signOut()
      .then(x => {
        localStorage.removeItem('auth');
      })
      .then(x => {
        this.storage.setItem('isLogged', false);
        this.router.navigate(['/']);
      })
      .catch(err => console.log(err));
  }
}
