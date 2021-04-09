import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NavItem } from '@shell/nav/nav.component';

@Component({
  selector: 'app-workspace',
  templateUrl: './workspace.component.html',
  styleUrls: ['./workspace.component.scss']
})
export class WorkspaceComponent implements OnInit {

  constructor(
    private readonly _router: Router
  ) { }

  ngOnInit(): void {
  }

  public navItems: NavItem[] = [
    { icon:"inventory", label: "Catalog Items" },
    { icon:"description", label: "Digital Assets" }
  ];

  handleLogoClick() {
    this._router.navigate(['']);
  }

  handleItemClick($event: NavItem) {        
    switch($event.label) {
      case "Digital Assets":
        this._router.navigate(['workspace','digital-assets']);
        break;
      case "Catalog Items":
        this._router.navigate(['workspace']);
        break;        
    }
  }
}
