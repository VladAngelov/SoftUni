import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/user/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  get isLogged(): boolean {
    return this.userService.isLogged;
  }

  constructor(public userService: UserService) { }

  ngOnInit(): void {
  }

  // loginHandler(): void {
  //   this.userService.login();
  // }

  logoutHandler(): void {
    this.userService.logout();
  }

}
