import { Component } from '@angular/core';
import { ThemePropertyService } from '@api';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(
    private readonly _themePropertyService: ThemePropertyService
  ) {

  }
}
