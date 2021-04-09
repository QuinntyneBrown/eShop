import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketListComponent } from './basket-list/basket-list.component';
import { BasketDetailComponent } from './basket-detail/basket-detail.component';
import { BasketEditorComponent } from './basket-editor/basket-editor.component';
import { SharedModule } from '@shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [BasketListComponent, BasketDetailComponent, BasketEditorComponent],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class BasketModule { }
