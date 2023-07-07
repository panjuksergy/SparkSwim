import { Injectable } from "@angular/core";
import {
  COMMON_SHARED_CONFIGURATION,
} from 'src/modules/common-shared/configuration/common-shared.config';

@Injectable()
export class PermissionStorageService {

  public async savePermisisons(permissions: string[]) {
    return await this.storageService.store(COMMON_SHARED_CONFIGURATION.authorization.userPermissions, permissions);
  }

  public async loadPermisisons(): Promise<string[]> {
    return await this.storageService.retrieve(COMMON_SHARED_CONFIGURATION.authorization.userPermissions);
  }

  public async clearPermisisons() {
    return await this.storageService.remove(COMMON_SHARED_CONFIGURATION.authorization.userPermissions);
  }
}
