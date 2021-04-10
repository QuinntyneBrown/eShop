import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { WorkspaceHeaderModule } from '@shared/workspace-header/workspace-header.module';
import { SharedModule } from '@shared/shared.module';
import { WorkspaceComponent } from './workspace/workspace.component';
import { WorkspaceRoutingModule } from './workspace-routing.module';
import { FooterModule } from '@shared/footer/footer.module';
import { HeaderModule } from '@shared/header/header.module';
import { NavModule } from '@shared/nav/nav.module';

@NgModule({
  declarations: [WorkspaceComponent],
  imports: [
    CommonModule,    
    WorkspaceHeaderModule,
    WorkspaceRoutingModule,
    SharedModule,
    HeaderModule,
    FooterModule,
    NavModule
  ]
})
export class WorkspaceModule { }
