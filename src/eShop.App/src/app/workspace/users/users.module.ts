import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserListComponent } from './user-list/user-list.component';
import { UserEditorComponent } from './user-editor/user-editor.component';
import { UserDetailComponent } from './user-detail/user-detail.component';
import { SharedModule } from '@shared/shared.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { UsersRoutingModule } from './users.routing-module';

@NgModule({
  declarations: [UserListComponent, UserEditorComponent, UserDetailComponent],
  imports: [
    CommonModule,
    SharedModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule,
    UsersRoutingModule
  ]
})
export class UsersModule { }
