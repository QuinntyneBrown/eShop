import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { CustomerEditorComponent } from './customer-editor/customer-editor.component';
import { CustomerDetailComponent } from './customer-detail/customer-detail.component';
import { SharedModule } from '@shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [CustomerListComponent, CustomerEditorComponent, CustomerDetailComponent],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class CustomerModule { }
