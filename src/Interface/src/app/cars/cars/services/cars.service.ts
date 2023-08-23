import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { CAR_LIST_MOCK } from 'src/app/shared/mocks/cars.mock';
import { CAR_MOCK } from 'src/app/shared/mocks/car.mock';

import { Car } from '../models/car.model';
import { environment } from './../../../../environments/environment.development';

12312;
@Injectable({
  providedIn: 'root',
})
export class CarsService {
  private apiEndpoints = { ...environment.apiEndpoints };

  constructor(private http: HttpClient) {}

  public getCarDetailsBasedOnFipe(codigoFipe: string, anoVeiculo: string | number): Observable<Car[]> {
    const serverPath = `${this.apiEndpoints.serverBasePath}${this.apiEndpoints.clientePath}/carros?codigoFipe=${codigoFipe}&anoVeiculo=${anoVeiculo}`;
    return this.http.get<Car[]>(`${serverPath}`);
    // return of(CAR_LIST_MOCK);
  }

  public getCarDetailsBasedOnPlaca(placa: string): Observable<Car> {
    const serverPath = `${this.apiEndpoints.serverBasePath}${this.apiEndpoints.clientePath}/listar/${placa}`;
    return this.http.get<Car>(`${serverPath}`);
    // return of(CAR_MOCK);
  }

  public saveCarDataBasedOnFipe(carList?: Car[]): Observable<Car[]> {
    const serverPath = `${this.apiEndpoints.serverBasePath}${this.apiEndpoints.clientePath}/AdicionarVeiculo`;
    // const mockedPath = `${this.apiEndpoints.mockedBasePath}${this.apiEndpoints.clientePath}/AdicionarVeiculo`;
    return this.http.post<Car[]>(`${serverPath}`, carList);
  }
}
