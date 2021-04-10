import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { NavItem } from '@shared/nav/nav.component';

@Component({
  selector: 'app-workspace',
  templateUrl: './workspace.component.html',
  styleUrls: ['./workspace.component.scss']
})
export class WorkspaceComponent  {

  constructor(
    private readonly _router: Router
  ) { }

  public readonly navItems: NavItem[] = [
    { icon:"inventory", label: "Catalog Items" },
    { icon:"shopping_cart", label: "Baskets" },
    { icon:"contacts", label: "Contacts" },
    { icon:"description", label: "Customers" },
    { icon:"folder", label: "Digital Assets" },
    { icon:"credit_card", label: "Orders" },
    { icon:"fingerprint", label: "Users" },
  ];

  handleLogoClick() {
    this._router.navigate(['']);
  }

  handleItemClick($event: NavItem) {       
    this._router.navigate(this._routeMap[$event.label]);
  }

  private readonly _routeMap = {
    "Digital Assets": ['workspace','digital-assets'],
    "Catalog Items": ['workspace'],
    "Baskets": ['workspace','baskets'],
    "Contacts": ['workspace','contacts'],
    "Customers": ['workspace','customers'],
    "Orders": ['workspace','orders'],
    "Users": ['workspace','users']
  }
}
