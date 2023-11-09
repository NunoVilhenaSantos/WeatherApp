// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

import { Permission } from './permission.model';

export class Role {
  constructor(
    public name = '',
    public description = '',
    public permissions: Permission[] = []
  ) { }

  public id = '';
  public usersCount = 0;
}
