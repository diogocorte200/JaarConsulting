import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchModeFormComponent } from './search-mode-form.component';

describe('SearchModeFormComponent', () => {
  let component: SearchModeFormComponent;
  let fixture: ComponentFixture<SearchModeFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SearchModeFormComponent]
    });
    fixture = TestBed.createComponent(SearchModeFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
