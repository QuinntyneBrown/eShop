import { OverlayRef } from '@angular/cdk/overlay';
import { Component, EventEmitter, OnDestroy, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { OrderService } from '@api';
import { BehaviorSubject, combineLatest, Observable, Subject } from 'rxjs';
import { map, takeUntil, tap } from 'rxjs/operators';
import { Order } from '@api';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.scss'],
  host: {
    'class':'g-layout__overlay-container'
  }
})
export class OrderDetailComponent implements OnDestroy {

  private readonly _destroyed: Subject<void> = new Subject();

  public order$: BehaviorSubject<Order> = new BehaviorSubject(null as any);

  @Output() public saved = new EventEmitter();

  public vm$ = combineLatest([
    this.order$
  ]).pipe(
    map(([order]) => {
      return {
        form: new FormGroup({
          order: new FormControl(order, [])
        })
      }
    })
  )

  constructor(
    private readonly _overlayRef: OverlayRef,
    private readonly _orderService: OrderService) {
  }

  public save(vm: { form: FormGroup}) {
    const order = vm.form.value.order;
    let obs$: Observable<{ order: Order }>;
    if(order.orderId) {
      obs$ = this._orderService.update({ order })
    }
    else {
      obs$ = this._orderService.create({ order })
    }

    obs$.pipe(
      takeUntil(this._destroyed),
      tap(x => {
        this.saved.next(x.order);
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
