import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss', '../../../form-style.scss']
})
export class LoginComponent implements OnInit {

  isLoading = false;
  errorMessage: string = null;

  constructor(
    private userService: UserService,
    private router: Router
  ) { }

  ngOnInit(): void {
  }

  submitFormHandler(fromValue: { email: string, password: string }): void {
    this.userService.login(fromValue).subscribe(() => {
      this.isLoading = false;
      this.errorMessage = '';
      this.router.navigate(['/']);
    }, (err) => {
      this.errorMessage = 'ERROR!';
      this.isLoading = false;
    });
  }

}
