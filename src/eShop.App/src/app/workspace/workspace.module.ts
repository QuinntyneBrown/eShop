import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkspaceComponent } from './workspace/workspace.component';
import { WorkspaceHeaderModule } from '@shell/workspace-header/workspace-header.module';
import { SharedModule } from '@shared/shared.module';
import { CatalogItemsModule } from './catalog-items/catalog-items.module';


@NgModule({
  declarations: [WorkspaceComponent],
  imports: [
    CommonModule,
    CatalogItemsModule,
    WorkspaceHeaderModule,
    SharedModule
  ]
})
export class WorkspaceModule { }
