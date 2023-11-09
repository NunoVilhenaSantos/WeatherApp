// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

import { Injectable, ErrorHandler } from '@angular/core';

@Injectable()
export class AppErrorHandler extends ErrorHandler {
  constructor() {
    super();
  }


  override handleError(error: Error) {
    if (confirm(`Fatal Error!\nAn unresolved error has occurred. Do you want to reload the page to correct this?\n\nError: ${error.message}`)) {
      window.location.reload();
    }

    super.handleError(error);
  }
}
