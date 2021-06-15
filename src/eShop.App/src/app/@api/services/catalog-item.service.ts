import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { CatalogItem } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class CatalogItemService implements IPagableService<CatalogItem> {

  uniqueIdentifierName: string = "catalogItemId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<CatalogItem>> {
    return this._client.get<EntityPage<CatalogItem>>(`${this._baseUrl}api/catalogItem/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<CatalogItem[]> {
    return this._client.get<{ catalogItems: CatalogItem[] }>(`${this._baseUrl}api/catalogItem`)
      .pipe(
        map(x => x.catalogItems)
      );
  }

  public getById(options: { catalogItemId: string }): Observable<CatalogItem> {
    return this._client.get<{ catalogItem: CatalogItem }>(`${this._baseUrl}api/catalogItem/${options.catalogItemId}`)
      .pipe(
        map(x => x.catalogItem)
      );
  }

  public remove(options: { catalogItem: CatalogItem }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/catalogItem/${options.catalogItem.catalogItemId}`);
  }

  public create(options: { catalogItem: CatalogItem }): Observable<{ catalogItem: CatalogItem }> {
    return this._client.post<{ catalogItem: CatalogItem }>(`${this._baseUrl}api/catalogItem`, { catalogItem: options.catalogItem });
  }

  public update(options: { catalogItem: CatalogItem }): Observable<{ catalogItem: CatalogItem }> {
    return this._client.put<{ catalogItem: CatalogItem }>(`${this._baseUrl}api/catalogItem`, { catalogItem: options.catalogItem });
  }
}
