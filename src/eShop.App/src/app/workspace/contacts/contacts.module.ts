import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContactListComponent } from './contact-list/contact-list.component';
import { ContactDetailComponent } from './contact-detail/contact-detail.component';
import { ContactEditorComponent } from './contact-editor/contact-editor.component';
import { SharedModule } from '@shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [ContactListComponent, ContactDetailComponent, ContactEditorComponent],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { 
        path: "", pathMatch: 'full', component: ContactListComponent,
      }
    ]),
    SharedModule,
    ReactiveFormsModule,
    FormsModule
  ]
})
export class ContactsModule { }
