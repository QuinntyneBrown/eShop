import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { WorkspaceComponent } from "./workspace/workspace.component";

const routes: Routes = [
  { 
    path: "", component: WorkspaceComponent,
    children: [
      { 
        path: "",  
        loadChildren: () => import("src/app/workspace/catalog-items/catalog-items.module").then(x => x.CatalogItemsModule)
      },
      { 
        path: "baskets",  
        loadChildren: () => import("src/app/workspace/baskets/baskets.module").then(x => x.BasketsModule)
      }, 
      { 
        path: "customers",  
        loadChildren: () => import("src/app/workspace/customers/customers.module").then(x => x.CustomersModule)
      },            
      { 
        path: "digital-assets",  
        loadChildren: () => import("src/app/workspace/digital-assets/digital-assets.module").then(x => x.DigitalAssetsModule)
      },  
      { 
        path: "orders",  
        loadChildren: () => import("src/app/workspace/orders/orders.module").then(x => x.OrdersModule)
      }, 
      { 
        path: "users",  
        loadChildren: () => import("src/app/workspace/users/users.module").then(x => x.UsersModule)
      }                 
    ]
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class WorkspaceRoutingModule {}