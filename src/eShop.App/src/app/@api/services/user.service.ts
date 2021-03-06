import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { User } from '@api';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class UserService implements IPagableService<User> {

  uniqueIdentifierName: string = "userId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getCurrent(): Observable<any> {
    return of({});
  }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<User>> {
    return this._client.get<EntityPage<User>>(`${this._baseUrl}api/user/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<User[]> {
    return this._client.get<{ users: User[] }>(`${this._baseUrl}api/user`)
      .pipe(
        map(x => x.users)
      );
  }

  public getById(options: { userId: string }): Observable<User> {
    return this._client.get<{ user: User }>(`${this._baseUrl}api/user/${options.userId}`)
      .pipe(
        map(x => x.user)
      );
  }

  public remove(options: { user: User }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/user/${options.user.userId}`);
  }

  public create(options: { user: User }): Observable<{ user: User }> {
    return this._client.post<{ user: User }>(`${this._baseUrl}api/user`, { user: options.user });
  }

  public update(options: { user: User }): Observable<{ user: User }> {
    return this._client.put<{ user: User }>(`${this._baseUrl}api/user`, { user: options.user });
  }
}
