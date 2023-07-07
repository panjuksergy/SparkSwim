import { Injectable } from "@angular/core";
import {
  PermissionStorageService,
  COMMON_SHARED_CONFIGURATION,
  AuthorizationTokenService,
    RestClientService,
} from 'src/modules/common-shared';
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';
import * as _ from 'lodash';

@Injectable()
export class PermissionService {
  baseUrl: string = `${environment.serverApiUrl}/${COMMON_SHARED_CONFIGURATION.membership.baseUrl}`;

  constructor(private restClientService: RestClientService,
              private authorizationTokenService: AuthorizationTokenService,
              private permissionStorageService: PermissionStorageService,
              private router: Router) {
  }

  public async load() {
    try {
      var token = await this.authorizationTokenService.getToken();

      if (token) {
        var headers = await this.authorizationTokenService.getAuthorizationHeaders();
        var response = await this.restClientService.post(this.baseUrl + `/auth/permissions`, {}, headers) as any;
        delete response.__originalResponse;
        var permissions = _.flattenDeep(Object.values(response));
        await this.permissionStorageService.savePermisisons(permissions);
      } else {
        await this.permissionStorageService.clearPermisisons();
      }
    } catch (e) {
      await this.permissionStorageService.clearPermisisons();
      this.router.navigate(['/login']);
    }
  }

  public async isAuthorized(permissions: string[]): Promise<boolean> {
    var cached = await this.getPermissions();
    return cached.some(_ => permissions.some(pm => pm === _));
  }

  public async clearPermisisonStorage() {
    await this.permissionStorageService.clearPermisisons();
  }

  private async getPermissions() {
    return await this.permissionStorageService.loadPermisisons();
  }
}
