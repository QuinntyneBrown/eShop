import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContentListComponent } from './content-list/content-list.component';
import { ContentDetailComponent } from './content-detail/content-detail.component';
import { ContentEditorComponent } from './content-editor/content-editor.component';
import { SharedModule } from '@shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { ContactDetailComponent } from '../contacts/contact-detail/contact-detail.component';



@NgModule({
  declarations: [ContentListComponent, ContentDetailComponent, ContentEditorComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { 
        path: "", pathMatch: 'full', component: ContentDetailComponent,
      },
      { 
        path: ":id", pathMatch: 'full', component: ContentDetailComponent,
      },
      { 
        path: "list", pathMatch: 'full', component: ContentListComponent,
      }            
    ]),
    SharedModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class ContentsModule { }
