import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchFipeFormComponent } from './search-fipe-form.component';

describe('SearchFipeFormComponent', () => {
  let component: SearchFipeFormComponent;
  let fixture: ComponentFixture<SearchFipeFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SearchFipeFormComponent]
    });
    fixture = TestBed.createComponent(SearchFipeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
