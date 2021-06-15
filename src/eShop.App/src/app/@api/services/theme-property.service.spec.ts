import { TestBed } from '@angular/core/testing';

import { ThemePropertyService } from './theme-property.service';

describe('ThemePropertyService', () => {
  let service: ThemePropertyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ThemePropertyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
