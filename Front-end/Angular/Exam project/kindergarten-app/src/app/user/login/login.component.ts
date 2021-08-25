import {
  Component,
  OnInit
} from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss', '../../../form-style.scss']
})

export class LoginComponent implements OnInit {

  isLoading = false;
  isLogged = false;

  constructor(
    private userService: UserService,
    private router: Router
  ) { }

  ngOnInit(): void {
    if (localStorage.getItem('auth')) {
      this.isLogged = true;
      console.log("LOGGED: " + this.isLogged);
      this.router.navigate["home"];
    }
  }

  submitFormHandler(fromValue: { email: string, password: string }): void {
    this.isLoading = true;
    this.userService.login(fromValue.email, fromValue.password);
    this.isLoading = false;
  }
}
