import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CatalogItemListComponent } from './catalog-item-list.component';

describe('CatalogItemListComponent', () => {
  let component: CatalogItemListComponent;
  let fixture: ComponentFixture<CatalogItemListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CatalogItemListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CatalogItemListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
