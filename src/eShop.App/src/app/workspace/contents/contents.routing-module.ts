import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { ContentListComponent } from "./content-list/content-list.component";
import { ContentDetailComponent } from "./content-detail/content-detail.component";

const routes: Routes = [
  { 
    path: "", component: ContentDetailComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ContentsRoutingModule {}
