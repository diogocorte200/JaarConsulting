import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';

import { CarsRoutingModule } from './cars-routing.module';
import { CarsComponent } from './cars/cars.component';
import { CarDataDisplayerComponent } from './cars/components/car-data-displayer/car-data-displayer.component';
import { CarListDataDisplayerComponent } from './cars/components/car-list-data-displayer/car-list-data-displayer.component';
import { SearchFipeFormComponent } from './cars/components/search-fipe-form/search-fipe-form.component';
import { SearchModeFormComponent } from './cars/components/search-mode-form/search-mode-form.component';
import { SearchPlacaFormComponent } from './cars/components/search-placa-form/search-placa-form.component';
import { SearchResultDisplayerComponent } from './cars/components/search-result-displayer/search-result-displayer.component';

@NgModule({
  declarations: [CarsComponent, SearchModeFormComponent, SearchResultDisplayerComponent, CarDataDisplayerComponent, SearchModeFormComponent, SearchFipeFormComponent, SearchPlacaFormComponent, CarListDataDisplayerComponent],
  imports: [
    CommonModule,
    CarsRoutingModule,
    MatButtonModule,
    MatFormFieldModule,
    MatIconModule,
    MatInputModule,
    MatSelectModule,
    ReactiveFormsModule,
  ],
})
export class CarsModule {}
