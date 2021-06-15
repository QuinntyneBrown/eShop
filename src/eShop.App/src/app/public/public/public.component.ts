import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ContentService, CustomizationService, HtmlContentService, SocialShareService } from '@api';
import { forkJoin } from 'rxjs';


@Component({
  selector: 'app-public',
  templateUrl: './public.component.html',
  styleUrls: ['./public.component.scss']
})
export class PublicComponent {

  constructor(
    private readonly _router: Router,
    private readonly _customizationService: CustomizationService,
    private readonly _contentService: ContentService,
    private readonly _htmlContentService: HtmlContentService,
    private readonly _socialShareService: SocialShareService
  ) { }


  public vm$ = forkJoin([
    this._customizationService.get(),
    this._contentService.get()
  ])

  public handleProfileClick() {
    this._router.navigate(['workspace']);
  }
}
