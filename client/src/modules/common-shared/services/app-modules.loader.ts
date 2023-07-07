import {
  PreloadingStrategy,
  Route,
} from '@angular/router';
import {
  Observable,
  of,
} from 'rxjs';
import { NavigationMenuContainer } from 'src/modules/common-shared/models/navigation-menu-container';
import { Injectable } from "@angular/core";

@Injectable()
export class AppModulesLoader implements PreloadingStrategy {
  static appLoadFinishTimeout;
  static loadedRoutes = [];

  preload(route: Route, load: Function): Observable<any> {
    if (AppModulesLoader.loadedRoutes.some(_ => _ === route)) {
      return of(null);
    }

    if (AppModulesLoader.appLoadFinishTimeout) {
      clearTimeout(AppModulesLoader.appLoadFinishTimeout);
    }

    const module = load(); // route.data && route.data.preload ? load() : of(null);

    module.subscribe({
      complete() {
        AppModulesLoader.loadedRoutes.push(route);
        AppModulesLoader.appLoadFinishTimeout = setTimeout(() => {
          NavigationMenuContainer.navSetupDone = true;
        }, 700);
      }
    });

    return module;
  }
}
