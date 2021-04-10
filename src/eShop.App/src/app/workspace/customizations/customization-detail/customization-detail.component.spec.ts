import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomizationDetailComponent } from './customization-detail.component';

describe('CustomizationDetailComponent', () => {
  let component: CustomizationDetailComponent;
  let fixture: ComponentFixture<CustomizationDetailComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomizationDetailComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomizationDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
