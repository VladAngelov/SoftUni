import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FirefliesComponent } from './fireflies.component';

describe('FirefliesComponent', () => {
  let component: FirefliesComponent;
  let fixture: ComponentFixture<FirefliesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FirefliesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(FirefliesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
