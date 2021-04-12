import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.scss'], 
  host: {
    "class":"g-layout__container"
  }
})
export class LandingComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

}
