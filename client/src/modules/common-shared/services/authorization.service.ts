import { Injectable } from '@angular/core';
import { Router } from "@angular/router";
import {
  AuthorizationTokenService,
  LocalStorageService,
  RestClientService,
  PermissionService,
  PermissionStorageService,
} from 'src/modules/common-shared';

@Injectable()
export class AuthorizationService extends AuthorizationTokenService {
  constructor(
    protected restClient: RestClientService,
    protected router: Router,
    protected permissionStorageService: PermissionStorageService,
    private permissionService: PermissionService,
  ) {
    super(restClient, router, permissionStorageService);
  }

  public async isAuthorized(permissions: string[]): Promise<boolean> {
    return this.permissionService.isAuthorized(permissions);
  }

  public async loadPermisisonsForUser() {
    await this.permissionService.load();
  }
}
