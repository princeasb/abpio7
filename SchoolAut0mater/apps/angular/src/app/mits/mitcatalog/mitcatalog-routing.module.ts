import { AuthGuard, PermissionGuard } from '@abp/ng.core';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MITCatalogComponent } from './components/mitcatalog.component';

const routes: Routes = [
  {
    path: '',
    component: MITCatalogComponent,
    canActivate: [AuthGuard, PermissionGuard],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class MITCatalogRoutingModule {}
