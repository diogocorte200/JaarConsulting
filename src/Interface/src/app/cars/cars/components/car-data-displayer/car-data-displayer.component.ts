import { Component, Input } from '@angular/core';
import { Car } from '../../models/car.model';

@Component({
  selector: 'app-car-data-displayer',
  templateUrl: './car-data-displayer.component.html',
  styleUrls: ['./car-data-displayer.component.scss']
})
export class CarDataDisplayerComponent {
  @Input()
  public car!: Car;

  @Input()
  public readOnlyMode: boolean = false;

}
