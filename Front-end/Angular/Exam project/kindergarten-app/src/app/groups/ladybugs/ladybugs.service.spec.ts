import { TestBed } from '@angular/core/testing';

import { LadybugsService } from './ladybugs.service';

describe('LadybugsService', () => {
  let service: LadybugsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LadybugsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
