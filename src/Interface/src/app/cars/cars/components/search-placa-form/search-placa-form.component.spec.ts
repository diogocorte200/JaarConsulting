import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchPlacaFormComponent } from './search-placa-form.component';

describe('SearchPlacaFormComponent', () => {
  let component: SearchPlacaFormComponent;
  let fixture: ComponentFixture<SearchPlacaFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SearchPlacaFormComponent]
    });
    fixture = TestBed.createComponent(SearchPlacaFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
