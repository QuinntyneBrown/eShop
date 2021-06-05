import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Role } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class RoleService implements IPagableService<Role> {

  uniqueIdentifierName: string = "roleId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { index: number; pageSize: number; }): Observable<EntityPage<Role>> {
    return this._client.get<EntityPage<Role>>(`${this._baseUrl}api/role/page/${options.pageSize}/${options.index}`)
  }

  public get(): Observable<Role[]> {
    return this._client.get<{ roles: Role[] }>(`${this._baseUrl}api/role`)
      .pipe(
        map(x => x.roles)
      );
  }

  public getById(options: { roleId: string }): Observable<Role> {
    return this._client.get<{ role: Role }>(`${this._baseUrl}api/role/${options.roleId}`)
      .pipe(
        map(x => x.role)
      );
  }

  public remove(options: { role: Role }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/role/${options.role.roleId}`);
  }

  public create(options: { role: Role }): Observable<{ role: Role }> {
    return this._client.post<{ role: Role }>(`${this._baseUrl}api/role`, { role: options.role });
  }
  
  public update(options: { role: Role }): Observable<{ role: Role }> {
    return this._client.put<{ role: Role }>(`${this._baseUrl}api/role`, { role: options.role });
  }
}