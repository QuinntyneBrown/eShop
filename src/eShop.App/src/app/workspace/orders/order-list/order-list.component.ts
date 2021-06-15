import { ChangeDetectionStrategy, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { DialogService } from '@shared/dialog.service';
import { BehaviorSubject, combineLatest, Observable, of, Subject } from 'rxjs';
import { map, switchMap, takeUntil, tap } from 'rxjs/operators';
import { Order } from '@api';
import { OrderDetailComponent } from '../order-detail/order-detail.component';
import { MatPaginator } from '@angular/material/paginator';
import { EntityDataSource } from '@shared/entity-data-source';
import { OrderService } from '@api';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  host: {
    'class':'g-layout__container g-layout__list-container'
  }
})
export class OrderListComponent implements OnDestroy {

  private readonly _destroyed$: Subject<void> = new Subject();
  @ViewChild(MatPaginator) paginator: MatPaginator;

  private readonly index$: BehaviorSubject<number> = new BehaviorSubject(0);
  private readonly pageSize$: BehaviorSubject<number> = new BehaviorSubject(5);
  private readonly _dataSource: EntityDataSource<Order> = new EntityDataSource(this._orderService);

  public readonly vm$: Observable<{
    dataSource: EntityDataSource<Order>,
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
        this._dataSource.getPage({ pageIndex: index, pageSize });
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
    private readonly _orderService: OrderService,
    private readonly _dialogService: DialogService,
  ) { }

  public edit(order: Order) {
    const component = this._dialogService.open<OrderDetailComponent>(OrderDetailComponent);
    component.order$.next(order);
    component.saved
    .pipe(
      takeUntil(this._destroyed$),
      tap(x => this._dataSource.update(x))
    ).subscribe();
  }

  public create() {
    this._dialogService.open<OrderDetailComponent>(OrderDetailComponent)
    .saved
    .pipe(
      takeUntil(this._destroyed$),
      tap(x => this.index$.next(this.index$.value))
    ).subscribe();
  }

  public delete(order: Order) {
    this._orderService.remove({ order }).pipe(
      takeUntil(this._destroyed$),
      tap(x => this.index$.next(this.index$.value))
    ).subscribe();
  }

  ngOnDestroy() {
    this._destroyed$.next();
    this._destroyed$.complete();
  }
}
