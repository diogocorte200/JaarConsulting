import { Component, Input, EventEmitter, Output } from '@angular/core';

import { Car } from '../../models/car.model';
import { SearchModeEnum } from 'src/app/shared/enums/search-mode.enum';

@Component({
  selector: 'app-search-result-displayer',
  templateUrl: './search-result-displayer.component.html',
  styleUrls: ['./search-result-displayer.component.scss'],
})
export class SearchResultDisplayerComponent {
  @Input()
  public carList!: Car[];

  @Input()
  public isFipeSearchMode!: boolean;

  @Output()
  public saveDataEmitter = new EventEmitter<Car[]>();

  public get hasCarList(): boolean {
    return this.carList && this.carList.length > 0;
  }

  public get allPlacasInserted(): boolean {
    return (
      !!this.hasCarList &&
      !this.carList.find((carInfo: Car) => carInfo.placa === undefined)
    );
  }

  public saveCarDetails(): void {
    this.saveDataEmitter.emit(this.carList);
  }

  public updateCarList(data: any) {
    this.carList[data.indexToUpdate] = data.carInfo;
  }
}
