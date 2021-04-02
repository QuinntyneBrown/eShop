import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CatalogItemEditorComponent } from './catalog-item-editor.component';

describe('CatalogItemEditorComponent', () => {
  let component: CatalogItemEditorComponent;
  let fixture: ComponentFixture<CatalogItemEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CatalogItemEditorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CatalogItemEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
