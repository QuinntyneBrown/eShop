import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { ContactListComponent } from "./contact-list/contact-list.component";

const routes: Routes = [
  { 
    path: "", component: ContactListComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContactsRoutingModule {}
