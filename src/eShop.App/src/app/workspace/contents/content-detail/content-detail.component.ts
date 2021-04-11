import { OverlayRef } from '@angular/cdk/overlay';
import { Component, EventEmitter, OnDestroy, Optional, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BehaviorSubject, combineLatest, Observable, Subject } from 'rxjs';
import { map, takeUntil, tap } from 'rxjs/operators';
import { Content } from '../content';
import { ContentService } from '../content.service';

@Component({
  selector: 'app-content-detail',
  templateUrl: './content-detail.component.html',
  styleUrls: ['./content-detail.component.scss'],
  host: {
    'class':'g-layout__container'
  }
})
export class ContentDetailComponent implements OnDestroy {

  private readonly _destroyed: Subject<void> = new Subject();

  public content$: BehaviorSubject<Content> = new BehaviorSubject(null as any);

  @Output() public saved = new EventEmitter();

  public vm$ = combineLatest([
    this.content$
  ]).pipe(
    map(([content]) => {
      return {
        form: new FormGroup({
          content: new FormControl(content, [])
        })
      }
    })
  )

  constructor(
    @Optional() private readonly _overlayRef: OverlayRef,
    private readonly _contentService: ContentService) {     
  }

  public save(vm: { form: FormGroup}) {
    const content = vm.form.value.content;
    let obs$: Observable<{ content: Content }>;
    if(content.contentId) {
      obs$ = this._contentService.update({ content })
    }   
    else {
      obs$ = this._contentService.create({ content })
    } 

    obs$.pipe(
      takeUntil(this._destroyed),      
      tap(x => {
        this.saved.next(x.content);
        this._overlayRef.dispose();
      })
    ).subscribe();
  }

  public cancel() {
    this._overlayRef.dispose();
  }

  ngOnDestroy() {
    this._destroyed.complete();
    this._destroyed.next();
  }
}
