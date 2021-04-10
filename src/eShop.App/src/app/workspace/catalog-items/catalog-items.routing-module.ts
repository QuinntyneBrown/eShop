import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { CatalogItemListComponent } from "./catalog-item-list/catalog-item-list.component";

const routes: Routes = [
  { 
    path: "", component: CatalogItemListComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CatalogItemsRoutingModule {}