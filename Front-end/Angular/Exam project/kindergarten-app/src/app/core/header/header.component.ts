import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/user/user.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {

  get isLogged(): boolean {
    if (localStorage.getItem('auth')) {
      return true;
    }
    return false;
  }

  constructor(public userService: UserService) { }

  ngOnInit(): void {

  }

  logoutHandler(): void {
    this.userService.logout();
  }
}
