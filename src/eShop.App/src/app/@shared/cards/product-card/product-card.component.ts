import { Component, Inject, Input } from '@angular/core';
import { CatalogItem } from '@api';
import { baseUrl } from '@core';

@Component({
  selector: 'app-product-card',
  templateUrl: './product-card.component.html',
  styleUrls: ['./product-card.component.scss']
})
export class ProductCardComponent {

  @Input() public product: CatalogItem | undefined;

  public get imageUrl() {
    return `${this._baseUrl}${this.product.catalogItemImages[0].imageUrl}`;
  }

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string
  ) {

  }
}
