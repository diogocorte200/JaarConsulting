import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Subject, takeUntil, tap } from 'rxjs';
import { SearchModeEnum } from 'src/app/shared/enums/search-mode.enum';

import { Car } from './models/car.model';
import { SearchFipeFilter } from './models/search-fipe-filter.model';
import { SearchPlacaFilter } from './models/search-placa-filter.model';
import { CarsService } from './services/cars.service';

@Component({
  selector: 'app-cars',
  templateUrl: './cars.component.html',
  styleUrls: ['./cars.component.scss'],
})
export class CarsComponent implements OnDestroy {
  public carsInfo: Car[] = [];

  private onDestroy$: Subject<void> = new Subject<void>();
  private searchMode!: 'FIPE' | 'PLACA';

  constructor(private carService: CarsService) {}

  ngOnDestroy(): void {
    this.onDestroy$.next();
    this.onDestroy$.unsubscribe();
  }

  public get allPlacasInserted(): boolean {
    return (
      !!this.hasCarInfos &&
      !this.carsInfo.find((carInfo: Car) => carInfo.placa === undefined)
    );
  }

  public get hasCarInfos(): boolean {
    return !!this.carsInfo && this.carsInfo.length > 0;
  }

  public get isFipeSearchMode(): boolean {
    return this.searchMode === SearchModeEnum.FIPE;
  }

  public get isPlacaSearchMode(): boolean {
    return this.searchMode === SearchModeEnum.PLACA;
  }

  public reset(): void {
    this.carsInfo = [];
  }

  public searchByPlaca(searchFilter: SearchPlacaFilter): void {
    this.carsInfo = [];
    this.carService
      .getCarDetailsBasedOnPlaca(searchFilter.placa)
      .pipe(
        tap((response: Car) => {
          this.carsInfo = [ response ];
        }),
        takeUntil(this.onDestroy$)
      )
      .subscribe();
  }

  public searchByFipe(searchFilter: SearchFipeFilter): void {
    this.carService
      .getCarDetailsBasedOnFipe(searchFilter.fipeCode, searchFilter.anoVeiculo)
      .pipe(
        tap((response: Car[]) => {
          this.carsInfo = response;
        }),
        takeUntil(this.onDestroy$)
      )
      .subscribe();
  }

  public searchModeChangeEvent(searchMode: any): void {
    this.carsInfo = [];
    this.searchMode = searchMode;
  }

  public saveCarDetails(carList: Car[]): void {
    this.carService.saveCarDataBasedOnFipe(carList).subscribe();
  }
}
