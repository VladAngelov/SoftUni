import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LionsComponent } from './lions.component';

describe('LionsComponent', () => {
  let component: LionsComponent;
  let fixture: ComponentFixture<LionsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LionsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
