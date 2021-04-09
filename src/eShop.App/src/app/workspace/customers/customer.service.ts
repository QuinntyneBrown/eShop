import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Customer } from './customer';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class CustomerService implements IPagableService<Customer> {

  uniqueIdentifierName: string = "customerId";

  constructor(
    @Inject(baseUrl) private _baseUrl: string,
    private _client: HttpClient
  ) { }

  getPage(options: { index: number; pageSize: number; }): Observable<EntityPage<Customer>> {
    return this._client.get<EntityPage<Customer>>(`${this._baseUrl}api/customer/page/${options.pageSize}/${options.index}`)
  }

  public get(): Observable<Customer[]> {
    return this._client.get<{ customers: Customer[] }>(`${this._baseUrl}api/customer`)
      .pipe(
        map(x => x.customers)
      );
  }

  public getById(options: { customerId: string }): Observable<Customer> {
    return this._client.get<{ customer: Customer }>(`${this._baseUrl}api/customer/${options.customerId}`)
      .pipe(
        map(x => x.customer)
      );
  }

  public remove(options: { customer: Customer }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/customer/${options.customer.customerId}`);
  }

  public create(options: { customer: Customer }): Observable<{ customer: Customer }> {
    return this._client.post<{ customer: Customer }>(`${this._baseUrl}api/customer`, { customer: options.customer });
  }
  
  public update(options: { customer: Customer }): Observable<{ customer: Customer }> {
    return this._client.put<{ customer: Customer }>(`${this._baseUrl}api/customer`, { customer: options.customer });
  }
}
