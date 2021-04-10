import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { forkJoin } from 'rxjs';
import { concatAll } from 'rxjs/operators';
import { ContentService } from 'src/app/workspace/contents/content.service';
import { CustomizationService } from 'src/app/workspace/customizations/customization.service';

@Component({
  selector: 'app-public',
  templateUrl: './public.component.html',
  styleUrls: ['./public.component.scss']
})
export class PublicComponent {

  constructor(
    private readonly _router: Router,
    private readonly _customizationService: CustomizationService,
    private readonly _contentService: ContentService
  ) { }


  public vm$ = forkJoin([
    this._customizationService.get(),
    this._contentService.get()
  ])
  
  public handleProfileClick() {    
    this._router.navigate(['workspace']);
  }
}
