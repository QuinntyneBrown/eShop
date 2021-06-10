import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { EntityActionsComponent } from './entity-actions.component';



@NgModule({
  declarations: [
    EntityActionsComponent
  ],
  exports: [
    EntityActionsComponent
  ],
  imports: [
    CommonModule
  ]
})
export class EntityActionsModule { }
