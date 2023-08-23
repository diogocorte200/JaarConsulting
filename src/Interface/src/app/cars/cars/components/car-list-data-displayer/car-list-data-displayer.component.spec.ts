import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarListDataDisplayerComponent } from './car-list-data-displayer.component';

describe('CarListDataDisplayerComponent', () => {
  let component: CarListDataDisplayerComponent;
  let fixture: ComponentFixture<CarListDataDisplayerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CarListDataDisplayerComponent]
    });
    fixture = TestBed.createComponent(CarListDataDisplayerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
