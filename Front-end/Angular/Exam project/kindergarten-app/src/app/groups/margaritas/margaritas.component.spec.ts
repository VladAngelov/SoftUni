import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MargaritasComponent } from './margaritas.component';

describe('MargaritasComponent', () => {
  let component: MargaritasComponent;
  let fixture: ComponentFixture<MargaritasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MargaritasComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MargaritasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
