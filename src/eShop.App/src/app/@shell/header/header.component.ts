import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
  host: {
    'class':'g_layout_container'
  }
})
export class HeaderComponent {
  @Output() searchClick: EventEmitter<any> = new EventEmitter();

  @Output() menuClick: EventEmitter<any> = new EventEmitter();

  @Output() profileClick: EventEmitter<any> = new EventEmitter();

  @Output() shoppingCartClick: EventEmitter<any> = new EventEmitter();
}
