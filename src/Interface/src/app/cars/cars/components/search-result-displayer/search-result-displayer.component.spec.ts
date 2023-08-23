import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchResultDisplayerComponent } from './search-result-displayer.component';

describe('SearchResultDisplayerComponent', () => {
  let component: SearchResultDisplayerComponent;
  let fixture: ComponentFixture<SearchResultDisplayerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SearchResultDisplayerComponent]
    });
    fixture = TestBed.createComponent(SearchResultDisplayerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
