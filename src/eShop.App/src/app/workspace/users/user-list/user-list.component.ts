import { ChangeDetectionStrategy, Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { DialogService } from '@shared/dialog.service';
import { BehaviorSubject, combineLatest, Observable, of, Subject } from 'rxjs';
import { map, switchMap, takeUntil, tap } from 'rxjs/operators';
import { User } from '@api';
import { UserDetailComponent } from '../user-detail/user-detail.component';
import { MatPaginator } from '@angular/material/paginator';
import { EntityDataSource } from '@shared/entity-data-source';
import { UserService } from '@api';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
  host: {
    'class':'g-layout__container g-layout__list-container'
  }
})
export class UserListComponent implements OnDestroy {

  private readonly _destroyed$: Subject<void> = new Subject();
  @ViewChild(MatPaginator) paginator: MatPaginator;

  private readonly index$: BehaviorSubject<number> = new BehaviorSubject(0);
  private readonly pageSize$: BehaviorSubject<number> = new BehaviorSubject(5);
  private readonly _dataSource: EntityDataSource<User> = new EntityDataSource(this._userService);

  public readonly vm$: Observable<{
    dataSource: EntityDataSource<User>,
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
    private readonly _userService: UserService,
    private readonly _dialogService: DialogService,
  ) { }

  public edit(user: User) {
    const component = this._dialogService.open<UserDetailComponent>(UserDetailComponent);
    component.user$.next(user);
    component.saved
    .pipe(
      takeUntil(this._destroyed$),
      tap(x => this._dataSource.update(x))
    ).subscribe();
  }

  public create() {
    this._dialogService.open<UserDetailComponent>(UserDetailComponent)
    .saved
    .pipe(
      takeUntil(this._destroyed$),
      tap(x => this.index$.next(this.index$.value))
    ).subscribe();
  }

  public delete(user: User) {
    this._userService.remove({ user }).pipe(
      takeUntil(this._destroyed$),
      tap(x => this.index$.next(this.index$.value))
    ).subscribe();
  }

  ngOnDestroy() {
    this._destroyed$.next();
    this._destroyed$.complete();
  }
}
