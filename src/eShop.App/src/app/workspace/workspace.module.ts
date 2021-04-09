import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkspaceHeaderModule } from '@shell/workspace-header/workspace-header.module';
import { SharedModule } from '@shared/shared.module';
import { CatalogItemsModule } from './catalog-items/catalog-items.module';
import { WorkspaceComponent } from './workspace/workspace.component';
import { WorkspaceRoutingModule } from './workspace-routing.module';
import { FooterModule } from '@shell/footer/footer.module';
import { HeaderModule } from '@shell/header/header.module';
import { NavModule } from '@shell/nav/nav.module';
import { DigitalAssetsModule } from './digital-assets/digital-assets.module';
import { OrdersModule } from './orders/orders.module';
import { BasketModule } from './baskets/basket.module';
import { CustomerModule } from './customers/customer.module';
import { UserModule } from './users/user.module';


@NgModule({
  declarations: [WorkspaceComponent],
  imports: [
    CommonModule,
    
    BasketModule,
    CatalogItemsModule,
    CustomerModule,
    DigitalAssetsModule,
    OrdersModule,
    UserModule,

    WorkspaceHeaderModule,
    WorkspaceRoutingModule,
    SharedModule,
    HeaderModule,
    FooterModule,
    NavModule
  ]
})
export class WorkspaceModule { }
