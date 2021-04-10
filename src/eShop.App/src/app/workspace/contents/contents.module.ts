import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContentListComponent } from './content-list/content-list.component';
import { ContentDetailComponent } from './content-detail/content-detail.component';
import { ContentEditorComponent } from './content-editor/content-editor.component';
import { ContentsRoutingModule } from './contents.routing-module';
import { SharedModule } from '@shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [ContentListComponent, ContentDetailComponent, ContentEditorComponent],
  imports: [
    CommonModule,
    ContentsRoutingModule,
    SharedModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class ContentsModule { }
