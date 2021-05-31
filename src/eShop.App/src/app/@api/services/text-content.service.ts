import { Injectable, Inject } from '@angular/core';
import { baseUrl } from '@core/constants';
import { HttpClient } from '@angular/common/http';
import { TextContent } from '@api';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { IPagableService } from '@core/ipagable-service';
import { EntityPage } from '@core/entity-page';

@Injectable({
  providedIn: 'root'
})
export class TextContentService implements IPagableService<TextContent> {

  uniqueIdentifierName: string = "textContentId";

  constructor(
    @Inject(baseUrl) private readonly _baseUrl: string,
    private readonly _client: HttpClient
  ) { }

  getPage(options: { index: number; pageSize: number; }): Observable<EntityPage<TextContent>> {
    return this._client.get<EntityPage<TextContent>>(`${this._baseUrl}api/textContent/page/${options.pageSize}/${options.index}`)
  }

  public get(): Observable<TextContent[]> {
    return this._client.get<{ textContents: TextContent[] }>(`${this._baseUrl}api/textContent`)
      .pipe(
        map(x => x.textContents)
      );
  }

  public getById(options: { textContentId: string }): Observable<TextContent> {
    return this._client.get<{ textContent: TextContent }>(`${this._baseUrl}api/textContent/${options.textContentId}`)
      .pipe(
        map(x => x.textContent)
      );
  }

  public remove(options: { textContent: TextContent }): Observable<void> {
    return this._client.delete<void>(`${this._baseUrl}api/textContent/${options.textContent.textContentId}`);
  }

  public create(options: { textContent: TextContent }): Observable<{ textContent: TextContent }> {
    return this._client.post<{ textContent: TextContent }>(`${this._baseUrl}api/textContent`, { textContent: options.textContent });
  }
  
  public update(options: { textContent: TextContent }): Observable<{ textContent: TextContent }> {
    return this._client.put<{ textContent: TextContent }>(`${this._baseUrl}api/textContent`, { textContent: options.textContent });
  }
}
