import { Component, OnInit } from '@angular/core';
import { of } from 'rxjs';

@Component({
  selector: 'app-product-grid',
  templateUrl: './product-grid.component.html',
  styleUrls: ['./product-grid.component.scss']
})
export class ProductGridComponent  {

  public vm$ = of([
    'assets/images/basket-1.jpg',
    'assets/images/vase-1.jpg',
    'assets/images/vase-2.jpg',
    'assets/images/vase-3.jpg',
    'assets/images/macrame-1.jpg',
    'assets/images/macrame-2.jpg',
    'assets/images/macrame-3.jpg',
    'assets/images/macrame-4.jpg',
    'assets/images/candle-holder-1.jpg',

  ]);
}
