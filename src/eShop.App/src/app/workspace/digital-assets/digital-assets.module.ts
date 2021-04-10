import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DigitalAssetListComponent } from './digital-asset-list/digital-asset-list.component';
import { DigitalAssetEditorComponent } from './digital-asset-editor/digital-asset-editor.component';
import { DigitalAssetDetailComponent } from './digital-asset-detail/digital-asset-detail.component';
import { SharedModule } from '@shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { DigitalAssetsRoutingModule } from './digital-assets.routing-module';
import { DigitalAssetUrlInputComponent } from './digital-asset-url-input/digital-asset-url-input.component';
import { DigitalAssetUploadModule } from './digital-asset-upload/digital-asset-upload.module';


@NgModule({
  declarations: [DigitalAssetListComponent, DigitalAssetEditorComponent, DigitalAssetDetailComponent, DigitalAssetUrlInputComponent],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    DigitalAssetsRoutingModule,
    DigitalAssetUploadModule
  ]
})
export class DigitalAssetsModule { }
