import { ChangeDetectionStrategy, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { DialogService } from '@shared/dialog.service';
import { BehaviorSubject, combineLatest, Observable, of, Subject } from 'rxjs';
import { map, switchMap, takeUntil, tap } from 'rxjs/operators';
import { Customer } from '../customer';
import { CustomerDetailComponent } from '../customer-detail/customer-detail.component';
import { CustomerService } from '../customer.service';
import { MatPaginator } from '@angular/material/paginator';
import { EntityDataSource } from '@shared/entity-data-source';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  host: {
    'class':'g-layout__container g-layout__list-container'
  }
})
export class CustomerListComponent implements OnDestroy {

  private readonly _destroyed$: Subject<void> = new Subject();
  @ViewChild(MatPaginator) paginator: MatPaginator;

  private readonly index$: BehaviorSubject<number> = new BehaviorSubject(0);
  private readonly pageSize$: BehaviorSubject<number> = new BehaviorSubject(5);
  private readonly _dataSource: EntityDataSource<Customer> = new EntityDataSource(this._customerService);

  public readonly vm$: Observable<{
    dataSource: EntityDataSource<Customer>,
    columnsToDisplay: string[],
    length$: Observable<number>,
    pageNumber: number,
    pageSize: number
  }> = combineLatest([this.index$, this.pageSize$ ])
  .pipe(
    switchMap(([index,pageSize]) => combineLatest([
      of([
        'name',
        'edit'
      ]),
      of(index),
      of(pageSize)  
    ])
    .pipe(
      map(([columnsToDisplay, pageNumber, pageSize]) => { 
        this._dataSource.getPage({ index, pageSize });
        return {
          dataSource: this._dataSource,
          columnsToDisplay,
          length$: this._dataSource.length$,
          pageSize,
          pageNumber
        }
      })
    ))
  );
  
  constructor(
    private readonly _customerService: CustomerService,
    private readonly _dialogService: DialogService,
  ) { }

  public edit(customer: Customer) {
    const component = this._dialogService.open<CustomerDetailComponent>(CustomerDetailComponent);
    component.customer$.next(customer);    
    component.saved
    .pipe(
      takeUntil(this._destroyed$),
      tap(x => this._dataSource.update(x))
    ).subscribe();
  }

  public create() {
    this._dialogService.open<CustomerDetailComponent>(CustomerDetailComponent)
    .saved
    .pipe(
      takeUntil(this._destroyed$),
      tap(x => this.index$.next(this.index$.value))
    ).subscribe();
  }

  public delete(customer: Customer) {    
    this._customerService.remove({ customer }).pipe(
      takeUntil(this._destroyed$),
      tap(x => this.index$.next(this.index$.value))
    ).subscribe();
  }
  
  ngOnDestroy() {
    this._destroyed$.next();
    this._destroyed$.complete();
  }
}
