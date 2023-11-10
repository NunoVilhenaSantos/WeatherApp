// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

import {Injectable} from '@angular/core';
import {RouterStateSnapshot, TitleStrategy} from '@angular/router';
import {Title} from '@angular/platform-browser';

import {Utilities} from './utilities';

@Injectable()
export class AppTitleService extends TitleStrategy {
  static appName: string | undefined;

  constructor(private readonly titleService: Title) {
    super();
  }

  override updateTitle(routerState: RouterStateSnapshot) {
    let title = this.buildTitle(routerState);

    if (title) {
      const fragment = routerState.url.split('#')[1];

      if (fragment) {
        title += ` | ${Utilities.toTitleCase(fragment)}`;
      }

      if (AppTitleService.appName) {
        title += ` - ${AppTitleService.appName}`;
      }

      this.titleService.setTitle(title);

    } else if (AppTitleService.appName) {
      this.titleService.setTitle(AppTitleService.appName);
    }
  }
}
