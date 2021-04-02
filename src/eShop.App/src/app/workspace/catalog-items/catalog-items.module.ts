import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CatalogItemEditorComponent } from './catalog-item-editor/catalog-item-editor.component';
import { CatalogItemListComponent } from './catalog-item-list/catalog-item-list.component';
import { CatalogItemDetailComponent } from './catalog-item-detail/catalog-item-detail.component';



@NgModule({
  declarations: [CatalogItemEditorComponent, CatalogItemListComponent, CatalogItemDetailComponent],
  imports: [
    CommonModule
  ]
})
export class CatalogItemsModule { }
