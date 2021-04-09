import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { WorkspaceComponent } from "./workspace/workspace.component";
import { CatalogItemListComponent } from "./catalog-items/catalog-item-list/catalog-item-list.component";
import { DigitalAssetListComponent } from "./digital-assets/digital-asset-list/digital-asset-list.component";


const routes: Routes = [
  { 
    path: "", component: WorkspaceComponent,
    children: [
      { path: "", component: CatalogItemListComponent },
      { path: "digital-assets", component: DigitalAssetListComponent }, 
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorkspaceRoutingModule {}