import { TestBed } from '@angular/core/testing';

import { MargaritasService } from './margaritas.service';

describe('MargaritasService', () => {
  let service: MargaritasService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MargaritasService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
