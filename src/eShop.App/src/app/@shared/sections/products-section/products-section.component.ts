import { Component, Input } from '@angular/core';
import { CatalogItem } from '@api';

@Component({
  selector: 'app-products-section',
  templateUrl: './products-section.component.html',
  styleUrls: ['./products-section.component.scss']
})
export class ProductsSectionComponent {

  @Input() public products: CatalogItem[] = [];

}
