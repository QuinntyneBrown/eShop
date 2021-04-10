import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Customization } from './customization';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class CustomizationService implements IPagableService<Customization> {

  uniqueIdentifierName: string = "customizationId";

  constructor(
    @Inject(baseUrl) private _baseUrl: string,
    private _client: HttpClient
  ) { }

  getPage(options: { index: number; pageSize: number; }): Observable<EntityPage<Customization>> {
    return this._client.get<EntityPage<Customization>>(`${this._baseUrl}api/customization/page/${options.pageSize}/${options.index}`)
  }

  public get(): Observable<Customization[]> {
    return this._client.get<{ customizations: Customization[] }>(`${this._baseUrl}api/customization`)
      .pipe(
        map(x => x.customizations)
      );
  }

  public getById(options: { customizationId: string }): Observable<Customization> {
    return this._client.get<{ customization: Customization }>(`${this._baseUrl}api/customization/${options.customizationId}`)
      .pipe(
        map(x => x.customization)
      );
  }

  public remove(options: { customization: Customization }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/customization/${options.customization.customizationId}`);
  }

  public create(options: { customization: Customization }): Observable<{ customization: Customization }> {
    return this._client.post<{ customization: Customization }>(`${this._baseUrl}api/customization`, { customization: options.customization });
  }
  
  public update(options: { customization: Customization }): Observable<{ customization: Customization }> {
    return this._client.put<{ customization: Customization }>(`${this._baseUrl}api/customization`, { customization: options.customization });
  }
}
