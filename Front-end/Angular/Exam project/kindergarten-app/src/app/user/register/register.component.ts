import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { emailValidator, rePasswordValidatorFactory } from 'src/app/shared/validators';
import { UserService } from '../user.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['../../../form-style.scss', './register.component.scss']
})
export class RegisterComponent implements OnInit {

  form: FormGroup;

  isLoading = false;

  constructor(
    private fb: FormBuilder,
    private userService: UserService,
    private router: Router
  ) {
    const passwordControl = this.fb.control('', [Validators.required, Validators.minLength(6)]);
    this.form = this.fb.group({
      email: ['', [Validators.required, emailValidator]],
      password: passwordControl,
      rePassword: ['', [Validators.required, Validators.minLength(6),
      rePasswordValidatorFactory(passwordControl)]]
    });
  }

  ngOnInit(): void {
  }

  submitHandler(): void {
    const data = this.form.value;
    this.isLoading = true;

    const email = this.form.controls['email'].value;
    const password = this.form.controls['password'].value;

    this.userService.register(email, password);
  }
}