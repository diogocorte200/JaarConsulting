import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarDataDisplayerComponent } from './car-data-displayer.component';

describe('CarDataDisplayerComponent', () => {
  let component: CarDataDisplayerComponent;
  let fixture: ComponentFixture<CarDataDisplayerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CarDataDisplayerComponent]
    });
    fixture = TestBed.createComponent(CarDataDisplayerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
