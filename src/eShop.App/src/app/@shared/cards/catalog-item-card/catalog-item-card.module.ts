import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CatalogItemCardComponent } from './catalog-item-card.component';
import { MaterialModule } from '@shared/material.module';



@NgModule({
  declarations: [CatalogItemCardComponent],
  exports: [
    CatalogItemCardComponent
  ],
  imports: [
    CommonModule,
    MaterialModule
  ]
})
export class CatalogItemCardModule { }
