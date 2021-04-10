import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomizationListComponent } from './customization-list/customization-list.component';
import { CustomizationDetailComponent } from './customization-detail/customization-detail.component';
import { CustomizationEditorComponent } from './customization-editor/customization-editor.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '@shared/shared.module';
import { CustomizationsRoutingModule } from './customizations.routing-module';



@NgModule({
  declarations: [CustomizationListComponent, CustomizationDetailComponent, CustomizationEditorComponent],
  imports: [
    CustomizationsRoutingModule,
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule
  ]
})
export class CustomizationsModule { }
