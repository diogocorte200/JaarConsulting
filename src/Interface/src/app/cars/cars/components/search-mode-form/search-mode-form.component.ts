import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { searchModeOptionsConfig } from '../../configs/search-mode-options.config';
import { Options } from '../../models/options.model';

@Component({
  selector: 'app-search-mode-form',
  templateUrl: './search-mode-form.component.html',
  styleUrls: ['./search-mode-form.component.scss']
})
export class SearchModeFormComponent {
  @Output()
  public searchModeChangeEventEmitter = new EventEmitter();

  public searchForm!: FormGroup;
  public searchModeOptions: Options[] = searchModeOptionsConfig;

  ngOnInit(): void {
    this.createForm();
  }

  private createForm(): void {
    this.searchForm = new FormGroup({
      searchMode: new FormControl(null, Validators.required),
    });
  }

  public reset(): void {
    const searchMode = this.searchForm.get('searchMode')?.value;
    this.searchModeChangeEventEmitter.emit(searchMode);
  }
}
