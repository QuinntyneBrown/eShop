import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CatalogItemEditorComponent } from './catalog-item-editor/catalog-item-editor.component';
import { CatalogItemListComponent } from './catalog-item-list/catalog-item-list.component';
import { CatalogItemDetailComponent } from './catalog-item-detail/catalog-item-detail.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { SharedModule } from '@shared/shared.module';
import { CatalogItemsRoutingModule } from './catalog-items.routing-module';

@NgModule({
  declarations: [CatalogItemEditorComponent, CatalogItemListComponent, CatalogItemDetailComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    SharedModule,
    CatalogItemsRoutingModule
  ]
})
export class CatalogItemsModule { }
