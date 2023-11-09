// ---------------------------------------------------
// Demo 1: https://quickapp-pro.azurewebsites.net
// Demo 2: https://quickapp-standard.azurewebsites.net
//
// --> Gun4Hire: contact@ebenmonney.com
// ---------------------------------------------------

import { Pipe, PipeTransform } from '@angular/core';


@Pipe({ name: 'groupBy' })
export class GroupByPipe implements PipeTransform {
  transform<T>(collection: T[], property: keyof T) {
    if (!collection) {
      return null;
    }

    const groupedCollection = collection.reduce((previous, current) => {
      const groupKey = current[property] as string;

      if (!previous[groupKey]) {
        previous[groupKey] = [current];
      } else {
        previous[groupKey].push(current);
      }

      return previous;
    }, {} as Record<string, T[]>);

    return Object.keys(groupedCollection)
      .map(key => ({ key, value: groupedCollection[key] }));
  }
}
