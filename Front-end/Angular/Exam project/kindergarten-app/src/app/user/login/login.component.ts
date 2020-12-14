import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss', '../../../form-style.scss']
})
export class LoginComponent implements OnInit {

  isLoading = false;

  constructor(private userService: UserService) { }

  ngOnInit(): void {
  }

  submitFormHandler(fromValue: { email: string, password: string }): void {
    this.isLoading = true;
    this.userService.login(fromValue.email, fromValue.password);
    debugger;
    this.isLoading = false;
  }
}
