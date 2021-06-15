import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Basket } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class BasketService implements IPagableService<Basket> {

  uniqueIdentifierName: string = "basketId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { pageIndex: number; pageSize: number; }): Observable<EntityPage<Basket>> {
    return this._client.get<EntityPage<Basket>>(`${this._baseUrl}api/basket/page/${options.pageSize}/${options.pageIndex}`)
  }

  public get(): Observable<Basket[]> {
    return this._client.get<{ baskets: Basket[] }>(`${this._baseUrl}api/basket`)
      .pipe(
        map(x => x.baskets)
      );
  }

  public getById(options: { basketId: string }): Observable<Basket> {
    return this._client.get<{ basket: Basket }>(`${this._baseUrl}api/basket/${options.basketId}`)
      .pipe(
        map(x => x.basket)
      );
  }

  public remove(options: { basket: Basket }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/basket/${options.basket.basketId}`);
  }

  public create(options: { basket: Basket }): Observable<{ basket: Basket }> {
    return this._client.post<{ basket: Basket }>(`${this._baseUrl}api/basket`, { basket: options.basket });
  }

  public update(options: { basket: Basket }): Observable<{ basket: Basket }> {
    return this._client.put<{ basket: Basket }>(`${this._baseUrl}api/basket`, { basket: options.basket });
  }
}
