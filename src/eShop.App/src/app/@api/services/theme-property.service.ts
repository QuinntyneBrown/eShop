import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { ThemeProperty } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class ThemePropertyService implements IPagableService<ThemeProperty> {

  uniqueIdentifierName: string = "themePropertyId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<ThemeProperty>> {
    return this._client.get<EntityPage<ThemeProperty>>(`${this._baseUrl}api/themeProperty/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<ThemeProperty[]> {
    return this._client.get<{ themeProperties: ThemeProperty[] }>(`${this._baseUrl}api/themeProperty`)
      .pipe(
        map(x => x.themeProperties)
      );
  }

  public getById(options: { themePropertyId: string }): Observable<ThemeProperty> {
    return this._client.get<{ themeProperty: ThemeProperty }>(`${this._baseUrl}api/themeProperty/${options.themePropertyId}`)
      .pipe(
        map(x => x.themeProperty)
      );
  }

  public remove(options: { themeProperty: ThemeProperty }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/themeProperty/${options.themeProperty.themePropertyId}`);
  }

  public create(options: { themeProperty: ThemeProperty }): Observable<{ themeProperty: ThemeProperty }> {
    return this._client.post<{ themeProperty: ThemeProperty }>(`${this._baseUrl}api/themeProperty`, { themeProperty: options.themeProperty });
  }
  
  public update(options: { themeProperty: ThemeProperty }): Observable<{ themeProperty: ThemeProperty }> {
    return this._client.put<{ themeProperty: ThemeProperty }>(`${this._baseUrl}api/themeProperty`, { themeProperty: options.themeProperty });
  }
}
