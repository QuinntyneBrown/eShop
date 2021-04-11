import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { CustomizationListComponent } from "./customization-list/customization-list.component";
import { CustomizationDetailComponent } from "./customization-detail/customization-detail.component";

const routes: Routes = [
  { 
    path: "", component: CustomizationDetailComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomizationsRoutingModule {}
