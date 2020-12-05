import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LadybugsComponent } from './ladybugs.component';

describe('LadybugsComponent', () => {
  let component: LadybugsComponent;
  let fixture: ComponentFixture<LadybugsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LadybugsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LadybugsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
