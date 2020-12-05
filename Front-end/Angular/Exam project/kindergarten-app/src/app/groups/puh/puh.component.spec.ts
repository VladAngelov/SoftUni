import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PuhComponent } from './puh.component';

describe('PuhComponent', () => {
  let component: PuhComponent;
  let fixture: ComponentFixture<PuhComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PuhComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PuhComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
