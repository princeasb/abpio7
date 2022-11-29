import { NgModule } from '@angular/core';
import { NgbCollapseModule, NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { PageModule } from '@abp/ng.components/page';
import { SharedModule } from '../shared/shared.module';
import { ProductRoutingModule } from './product-routing.module';
import { ProductComponent } from './product.component';

@NgModule({
  declarations: [ProductComponent],
  imports: [ProductRoutingModule, SharedModule, NgbCollapseModule, NgbDatepickerModule, PageModule],
})
export class ProductModule {}
