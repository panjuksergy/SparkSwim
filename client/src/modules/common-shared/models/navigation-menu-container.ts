import { EventEmitter } from '@angular/core';
import { NavigationItemModel } from 'src/modules/common-shared/models/navigation-item.model';

export class NavigationMenuContainer {
  static navSetupDone: boolean = false;
  static flattenNavigationMenus: NavigationItemModel[] = [];
  static navigationMenus: NavigationItemModel[] = [];
  static onNavigationMenuInitializing = new EventEmitter<any>();
}
