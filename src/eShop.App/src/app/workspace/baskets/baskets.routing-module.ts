import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { BasketListComponent } from "./basket-list/basket-list.component";

const routes: Routes = [
  { 
    path: "", component: BasketListComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class BasketsRoutingModule {}
