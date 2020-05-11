import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { Dueño } from '../perfil/models/Dueño';

@Injectable({
  providedIn: 'root'
})
export class DueñoService {

  baseUrl: string;

  constructor(
     private http: HttpClient,
     @Inject('BASE_URL') baseUrl: string,
     private handleErrorService: HandleHttpErrorService
  ) {
     this.baseUrl = baseUrl;
  }


  get(): Observable<Dueño[]> {
     return this.http.get<Dueño[]>(this.baseUrl + 'api/Dueño').pipe(
        tap(_ => this.handleErrorService.log('datos recibidos')),
        catchError(this.handleErrorService.handleError<Dueño[]>('Consulta Dueño', null))
     );
  }

  post(dueño: Dueño): Observable<Dueño> {
     return this.http.post<Dueño>(this.baseUrl + 'api/Dueño', dueño).pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Dueño>('Registrar Dueño', null))
     );
  }

}
