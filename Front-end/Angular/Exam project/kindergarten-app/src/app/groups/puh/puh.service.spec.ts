import { TestBed } from '@angular/core/testing';

import { PuhService } from './puh.service';

describe('PuhService', () => {
  let service: PuhService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PuhService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
