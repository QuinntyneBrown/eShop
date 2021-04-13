import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketListComponent } from './basket-list/basket-list.component';
import { BasketDetailComponent } from './basket-detail/basket-detail.component';
import { BasketEditorComponent } from './basket-editor/basket-editor.component';
import { SharedModule } from '@shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [BasketListComponent, BasketDetailComponent, BasketEditorComponent],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forChild([
      { 
        path: "", pathMatch: 'full', component: BasketListComponent,
      }
    ])
  ]
})
export class BasketsModule { }
