import { Component, EventEmitter, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { SearchPlacaFilter } from '../../models/search-placa-filter.model';

@Component({
  selector: 'app-search-placa-form',
  templateUrl: './search-placa-form.component.html',
  styleUrls: ['./search-placa-form.component.scss']
})
export class SearchPlacaFormComponent {
  @Output()
  public searchByPlacaEmitter = new EventEmitter<SearchPlacaFilter>();

  public searchByPlacaForm!: FormGroup;

  ngOnInit(): void {
    this.createForm();
  }

  public searchByPlacaCode(): void {
    const filter: SearchPlacaFilter = this.constructFitlerObject();
    this.searchByPlacaEmitter.emit(filter);
  }

  private constructFitlerObject(): SearchPlacaFilter {
    return { placa: this.searchByPlacaForm.get('placa')?.value};
  }

  private createForm(): void {
    this.searchByPlacaForm = new FormGroup({
      placa: new FormControl(null, Validators.required),
    });
  }
}
