import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { SearchFipeFilter } from '../../models/search-fipe-filter.model';


@Component({
  selector: 'app-search-fipe-form',
  templateUrl: './search-fipe-form.component.html',
  styleUrls: ['./search-fipe-form.component.scss'],
})
export class SearchFipeFormComponent implements OnInit {
  @Output()
  public searchByFipeEmitter = new EventEmitter<SearchFipeFilter>();

  public searchByFipeForm!: FormGroup;

  ngOnInit(): void {
    this.createForm();
  }

  public searchByFipeCode(): void {
    const filter: SearchFipeFilter = this.constructFitlerObject();
    this.searchByFipeEmitter.emit(filter);
  }

  private constructFitlerObject(): SearchFipeFilter {
    return {
      anoVeiculo: this.searchByFipeForm.get('anoVeiculo')?.value,
      fipeCode: this.searchByFipeForm.get('fipeCode')?.value,
    };
  }

  private createForm(): void {
    this.searchByFipeForm = new FormGroup({
      anoVeiculo: new FormControl(null, Validators.required),
      fipeCode: new FormControl(null, Validators.required),
    });
  }
}
