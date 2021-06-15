import { OverlayRef } from '@angular/cdk/overlay';
import { Component, EventEmitter, OnDestroy, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { BehaviorSubject, combineLatest, Observable, Subject } from 'rxjs';
import { map, takeUntil, tap } from 'rxjs/operators';
import { Customer } from '@api';
import { CustomerService } from '@api';

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.scss'],
  host: {
    'class':'g-layout__overlay-container'
  }
})
export class CustomerDetailComponent implements OnDestroy {

  private readonly _destroyed: Subject<void> = new Subject();

  public customer$: BehaviorSubject<Customer> = new BehaviorSubject(null as any);

  @Output() public saved = new EventEmitter();

  public vm$ = combineLatest([
    this.customer$
  ]).pipe(
    map(([customer]) => {
      return {
        form: new FormGroup({
          customer: new FormControl(customer, [])
        })
      }
    })
  )

  constructor(
    private readonly _overlayRef: OverlayRef,
    private readonly _customerService: CustomerService) {
  }

  public save(vm: { form: FormGroup}) {
    const customer = vm.form.value.customer;
    let obs$: Observable<{ customer: Customer }>;
    if(customer.customerId) {
      obs$ = this._customerService.update({ customer })
    }
    else {
      obs$ = this._customerService.create({ customer })
    }

    obs$.pipe(
      takeUntil(this._destroyed),
      tap(x => {
        this.saved.next(x.customer);
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
