import { TestBed } from '@angular/core/testing';

import { LionsService } from './lions.service';

describe('LionsService', () => {
  let service: LionsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LionsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
