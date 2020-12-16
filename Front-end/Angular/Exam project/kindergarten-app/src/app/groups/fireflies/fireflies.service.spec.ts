import { TestBed } from '@angular/core/testing';

import { FirefliesService } from './fireflies.service';

describe('FirefliesService', () => {
  let service: FirefliesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FirefliesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
