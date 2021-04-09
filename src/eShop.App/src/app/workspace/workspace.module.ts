import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkspaceHeaderModule } from '@shell/workspace-header/workspace-header.module';
import { SharedModule } from '@shared/shared.module';
import { CatalogItemsModule } from './catalog-items/catalog-items.module';
import { WorkspaceComponent } from './workspace/workspace.component';
import { WorkspaceRoutingModule } from './workspace-routing.module';
import { FooterModule } from '@shell/footer/footer.module';
import { HeaderModule } from '@shell/header/header.module';


@NgModule({
  declarations: [WorkspaceComponent],
  imports: [
    CommonModule,
    CatalogItemsModule,
    WorkspaceHeaderModule,
    WorkspaceRoutingModule,
    SharedModule,
    HeaderModule,
    FooterModule
  ]
})
export class WorkspaceModule { }
