import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  isLoading = false;
  errorMessage: string = null;

  form = {
    email: {
      touched: false,
      value: ''
    },
    password: {
      touched: false,
      value: ''
    }
  }

  get showEmailError(): boolean {
    return this.form.email.value.length === 0 &&
      this.form.email.touched;
  }
  get showPasswordError(): boolean {
    return this.form.password.value.length < 0 &&
      this.form.password.touched;
  }
  get hasFormErrors(): boolean {
    return this.form.email.value.length === 0 ||
      this.form.password.value.length < 4;
  }

  constructor(
    private userService: UserService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  updateInputValue(name: 'email' | 'password', value: string): void {
    this.form[name].touched = true;
    this.form[name].value = value;
  }

  submitFormHandler(): void {
    const { email: { value: email }, password: { value: password } } = this.form;
    this.userService.login({ email, password }).subscribe(() => {
      this.isLoading = false;
      this.errorMessage = '';
      this.router.navigate(['/']);
    }, (err) => {
      this.errorMessage = 'ERROR!';
      this.isLoading = false;
    });
  }

}
