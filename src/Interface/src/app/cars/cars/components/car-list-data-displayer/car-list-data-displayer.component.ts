import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { Car } from '../../models/car.model';

@Component({
  selector: 'app-car-list-data-displayer',
  templateUrl: './car-list-data-displayer.component.html',
  styleUrls: ['./car-list-data-displayer.component.scss']
})
export class CarListDataDisplayerComponent {
  @Input() car: Car = {};
  @Input() index!: number;

  @Output() addPlacaToCarInfo = new EventEmitter();

  public addPlacaForm!: FormGroup;

  ngOnInit(): void {
    this.createForm();
  }

  public addPlacaToCarsInfo(): void {
    this.car.placa = this.addPlacaForm.get('placa')?.value;
    this.addPlacaToCarInfo.emit({ carInfo: this.car, indexToUpdate: this.index })
  }

  private createForm(): void {
    this.addPlacaForm = new FormGroup({
      placa: new FormControl(null, Validators.required),
    });
  }
}
