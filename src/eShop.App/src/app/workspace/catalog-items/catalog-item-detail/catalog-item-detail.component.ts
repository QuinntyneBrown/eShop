import { OverlayRef } from '@angular/cdk/overlay';
import { Component, EventEmitter, OnDestroy, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BehaviorSubject, combineLatest, Observable, Subject } from 'rxjs';
import { map, takeUntil, tap } from 'rxjs/operators';
import { CatalogItem } from '../catalog-item';
import { CatalogItemService } from '../catalog-item.service';

@Component({
  selector: 'app-catalog-item-detail',
  templateUrl: './catalog-item-detail.component.html',
  styleUrls: ['./catalog-item-detail.component.scss']
})
export class CatalogItemDetailComponent implements OnDestroy {

  private readonly _destroyed: Subject<void> = new Subject();

  public catalogItem$: BehaviorSubject<CatalogItem> = new BehaviorSubject(null as any);

  @Output() public saved = new EventEmitter();

  public vm$ = combineLatest([
    this.catalogItem$
  ]).pipe(
    map(([catalogItem]) => {
      return {
        form: new FormGroup({
          catalogItem: new FormControl(catalogItem, [])
        })
      }
    })
  )

  constructor(
    private readonly _overlayRef: OverlayRef,
    private readonly _catalogItemService: CatalogItemService) {     
  }

  public save(vm: { form: FormGroup}) {
    const catalogItem = vm.form.value.catalogItem;
    let obs$: Observable<{ catalogItem: CatalogItem }>;
    if(catalogItem.catalogItemId) {
      obs$ = this._catalogItemService.update({ catalogItem })
    }   
    else {
      obs$ = this._catalogItemService.create({ catalogItem })
    } 

    obs$.pipe(
      takeUntil(this._destroyed),      
      tap(x => {
        this.saved.next(x.catalogItem);
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
