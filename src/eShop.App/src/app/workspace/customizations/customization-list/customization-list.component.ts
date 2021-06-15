import { ChangeDetectionStrategy, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { DialogService } from '@shared/dialog.service';
import { BehaviorSubject, combineLatest, Observable, of, Subject } from 'rxjs';
import { map, switchMap, takeUntil, tap } from 'rxjs/operators';
import { Customization } from '@api';
import { CustomizationDetailComponent } from '../customization-detail/customization-detail.component';
import { CustomizationService } from '@api';
import { MatPaginator } from '@angular/material/paginator';
import { EntityDataSource } from '@shared/entity-data-source';

@Component({
  selector: 'app-customization-list',
  templateUrl: './customization-list.component.html',
  styleUrls: ['./customization-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  host: {
    'class':'g-layout__container g-layout__list-container'
  }
})
export class CustomizationListComponent implements OnDestroy {

  private readonly _destroyed$: Subject<void> = new Subject();
  @ViewChild(MatPaginator) paginator: MatPaginator;

  private readonly index$: BehaviorSubject<number> = new BehaviorSubject(0);
  private readonly pageSize$: BehaviorSubject<number> = new BehaviorSubject(5);
  private readonly _dataSource: EntityDataSource<Customization> = new EntityDataSource(this._customizationService);

  public readonly vm$: Observable<{
    dataSource: EntityDataSource<Customization>,
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
    private readonly _customizationService: CustomizationService,
    private readonly _dialogService: DialogService,
  ) { }

  public edit(customization: Customization) {
    const component = this._dialogService.open<CustomizationDetailComponent>(CustomizationDetailComponent);
    component.customization$.next(customization);
    component.saved
    .pipe(
      takeUntil(this._destroyed$),
      tap(x => this._dataSource.update(x))
    ).subscribe();
  }

  public create() {
    this._dialogService.open<CustomizationDetailComponent>(CustomizationDetailComponent)
    .saved
    .pipe(
      takeUntil(this._destroyed$),
      tap(x => this.index$.next(this.index$.value))
    ).subscribe();
  }

  public delete(customization: Customization) {
    this._customizationService.remove({ customization }).pipe(
      takeUntil(this._destroyed$),
      tap(x => this.index$.next(this.index$.value))
    ).subscribe();
  }

  ngOnDestroy() {
    this._destroyed$.next();
    this._destroyed$.complete();
  }
}
