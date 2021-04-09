import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DigitalAssetListComponent } from './digital-asset-list/digital-asset-list.component';
import { DigitalAssetEditorComponent } from './digital-asset-editor/digital-asset-editor.component';
import { DigitalAssetDetailComponent } from './digital-asset-detail/digital-asset-detail.component';
import { SharedModule } from '@shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [DigitalAssetListComponent, DigitalAssetEditorComponent, DigitalAssetDetailComponent],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule
  ]
})
export class DigitalAssetsModule { }
