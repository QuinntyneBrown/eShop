import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BasketEditorComponent } from './basket-editor.component';

describe('BasketEditorComponent', () => {
  let component: BasketEditorComponent;
  let fixture: ComponentFixture<BasketEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BasketEditorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BasketEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
