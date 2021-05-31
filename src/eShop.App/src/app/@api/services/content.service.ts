import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { Content } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class ContentService implements IPagableService<Content> {

  uniqueIdentifierName: string = "contentId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { index: number; pageSize: number; }): Observable<EntityPage<Content>> {
    return this._client.get<EntityPage<Content>>(`${this._baseUrl}api/content/page/${options.pageSize}/${options.index}`)
  }

  public get(): Observable<Content[]> {
    return this._client.get<{ contents: Content[] }>(`${this._baseUrl}api/content`)
      .pipe(
        map(x => x.contents)
      );
  }

  public getById(options: { contentId: string }): Observable<Content> {
    return this._client.get<{ content: Content }>(`${this._baseUrl}api/content/${options.contentId}`)
      .pipe(
        map(x => x.content)
      );
  }

  public remove(options: { content: Content }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/content/${options.content.contentId}`);
  }

  public create(options: { content: Content }): Observable<{ content: Content }> {
    return this._client.post<{ content: Content }>(`${this._baseUrl}api/content`, { content: options.content });
  }
  
  public update(options: { content: Content }): Observable<{ content: Content }> {
    return this._client.put<{ content: Content }>(`${this._baseUrl}api/content`, { content: options.content });
  }
}
