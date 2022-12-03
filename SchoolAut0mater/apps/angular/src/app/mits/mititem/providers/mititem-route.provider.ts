import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const MITS_MITITEM_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/mititems',
        iconClass: 'fas fa-tools',
        name: 'CoreService::Menu:MITItems',
        layout: eLayoutType.application,
        requiredPolicy: 'CoreService.MITItems',
      },
    ]);
  };
}
