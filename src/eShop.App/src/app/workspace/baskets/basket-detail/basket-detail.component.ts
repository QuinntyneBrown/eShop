import { OverlayRef } from '@angular/cdk/overlay';
import { Component, EventEmitter, OnDestroy, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BehaviorSubject, combineLatest, Observable, Subject } from 'rxjs';
import { map, takeUntil, tap } from 'rxjs/operators';
import { Basket, BasketService } from '@api';

@Component({
  selector: 'app-basket-detail',
  templateUrl: './basket-detail.component.html',
  styleUrls: ['./basket-detail.component.scss'],
  host: {
    'class':'g-layout__overlay-container'
  }
})
export class BasketDetailComponent implements OnDestroy {

  private readonly _destroyed: Subject<void> = new Subject();

  public basket$: BehaviorSubject<Basket> = new BehaviorSubject(null as any);

  @Output() public saved = new EventEmitter();

  public vm$ = combineLatest([
    this.basket$
  ]).pipe(
    map(([basket]) => {
      return {
        form: new FormGroup({
          basket: new FormControl(basket, [])
        })
      }
    })
  )

  constructor(
    private readonly _overlayRef: OverlayRef,
    private readonly _basketService: BasketService) {     
  }

  public save(vm: { form: FormGroup}) {
    const basket = vm.form.value.basket;
    let obs$: Observable<{ basket: Basket }>;
    if(basket.basketId) {
      obs$ = this._basketService.update({ basket })
    }   
    else {
      obs$ = this._basketService.create({ basket })
    } 

    obs$.pipe(
      takeUntil(this._destroyed),      
      tap(x => {
        this.saved.next(x.basket);
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
