import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CatalogItemCardComponent } from './catalog-item-card.component';

describe('CatalogItemCardComponent', () => {
  let component: CatalogItemCardComponent;
  let fixture: ComponentFixture<CatalogItemCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CatalogItemCardComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CatalogItemCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
