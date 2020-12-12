import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router, CanActivateChild } from '@angular/router';
import { Observable } from 'rxjs';
import { UserService } from 'src/app/user/user.service';

@Injectable()
export class AccessGuard implements CanActivateChild {

  constructor(
    private userService: UserService,
    private router: Router
  ) { }

  canActivateChild(childRoute: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
    const isLoggedFromData = childRoute.data.isLogged;
    if (typeof isLoggedFromData === 'boolean' &&
      isLoggedFromData == this.userService.isLogged) {
      return true;
    }
    const url = this.router.url;
    this.router.navigateByUrl(url);
    return false;
  }

}
