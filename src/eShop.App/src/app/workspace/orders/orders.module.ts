import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { OrderDetailComponent } from './order-detail/order-detail.component';
import { OrderEditorComponent } from './order-editor/order-editor.component';
import { OrderListComponent } from './order-list/order-list.component';
import { SharedModule } from '@shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { OrdersRoutingModule } from './orders.routing-module';



@NgModule({
  declarations: [OrderDetailComponent, OrderEditorComponent, OrderListComponent],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    OrdersRoutingModule
  ]
})
export class OrdersModule { }
