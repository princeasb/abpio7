import { eLayoutType, RoutesService } from '@abp/ng.core';
import { APP_INITIALIZER } from '@angular/core';

export const MITS_MITCATALOG_ROUTE_PROVIDER = [
  { provide: APP_INITIALIZER, useFactory: configureRoutes, deps: [RoutesService], multi: true },
];

function configureRoutes(routes: RoutesService) {
  return () => {
    routes.add([
      {
        path: '/mitcatalogs',
        iconClass: 'fas fa-fa-wrench',
        name: 'CoreService::Menu:MITCatalogs',
        layout: eLayoutType.application,
        requiredPolicy: 'CoreService.MITCatalogs',
      },
    ]);
  };
}
