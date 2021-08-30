import {
  Component,
  OnDestroy
} from '@angular/core';

import { UserService } from './user/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnDestroy {
  title = 'kindergarten-app';

  constructor(public userService: UserService) { }

  ngOnDestroy(): void {
    this.userService.logout();
    localStorage.setItem('auth', null);
    localStorage.setItem('isLogged', "false");
  }

}
