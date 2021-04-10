import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { CustomizationListComponent } from "./customization-list/customization-list.component";

const routes: Routes = [
  { 
    path: "", component: CustomizationListComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomizationsRoutingModule {}
