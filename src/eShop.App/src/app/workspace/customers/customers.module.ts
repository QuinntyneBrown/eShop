import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CustomerListComponent } from './customer-list/customer-list.component';
import { CustomerEditorComponent } from './customer-editor/customer-editor.component';
import { CustomerDetailComponent } from './customer-detail/customer-detail.component';
import { SharedModule } from '@shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CustomersRoutingModule } from './customers.routing-module';



@NgModule({
  declarations: [CustomerListComponent, CustomerEditorComponent, CustomerDetailComponent],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    CustomersRoutingModule
  ]
})
export class CustomersModule { }
