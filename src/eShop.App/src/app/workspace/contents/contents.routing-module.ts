import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { ContentListComponent } from "./content-list/content-list.component";

const routes: Routes = [
  { 
    path: "", component: ContentListComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContentsRoutingModule {}
