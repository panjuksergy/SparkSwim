import {
  ActivatedRouteSnapshot,
  CanActivate,
  Router,
  RouterStateSnapshot,
} from '@angular/router';
import { Injectable } from '@angular/core';
import {
  AuthorizationService,
  LocalStorageService,
} from 'src/modules/common-shared';

@Injectable()
export class PermissionAuthorizeService implements CanActivate {
  constructor(
    private authorizationService: AuthorizationService,
    private storageService: LocalStorageService,
    private router: Router,
  ) {  }

  async canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    if (!await this.authorizationService.isAuthenticated()) {
      this.router.navigate(['/', 'login'], {
        queryParams: {
          redirect: state.url
        }
      });
      this.storageService.clear();
      return false;
    }

    if (!route.data.permissions || !route.data.permissions.length) {
      return true;
    }

    if (!await this.authorizationService.isAuthorized(route.data.permissions)) {
      if (route.data.nextRoute) {
        this.router.navigate([route.data.nextRoute]);
        return false;
      }
      this.router.navigate(['/', 'unauthorized'], {
        queryParams: {
          url: state.url
        },
      });
      return false;
    }

    return true;
  }
}
