import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CustomizationEditorComponent } from './customization-editor.component';

describe('CustomizationEditorComponent', () => {
  let component: CustomizationEditorComponent;
  let fixture: ComponentFixture<CustomizationEditorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CustomizationEditorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CustomizationEditorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
