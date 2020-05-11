import { Injectable, Inject } from '@angular/core';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';
import { Restaurante } from '../perfil/models/restaurante';
import { HttpClient, HttpHeaders } from '@angular/common/http';
const httpOptionsPut = {
   headers: new HttpHeaders({ 'Content-Type': 'application/json' }),
   responseType: 'text'
 };

 const httpOptions = {
   headers: new HttpHeaders({ 'Content-Type': 'application/json' })
 };
@Injectable({
  providedIn: 'root'
})
export class RestauranteService {

  baseUrl: string;

  constructor(
     private http: HttpClient,
     @Inject('BASE_URL') baseUrl: string,
     private handleErrorService: HandleHttpErrorService
  ) {
     this.baseUrl = baseUrl;
  }


  get(): Observable<Restaurante[]> {
     return this.http.get<Restaurante[]>(this.baseUrl + 'api/Restaurante').pipe(
        tap(_ => this.handleErrorService.log('datos recibidos')),
        catchError(this.handleErrorService.handleError<Restaurante[]>('Consulta Restaurante', null))
     );
  }

  post(restaurante: Restaurante): Observable<Restaurante> {
     return this.http.post<Restaurante>(this.baseUrl + 'api/Restaurante', restaurante).pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<Restaurante>('Registrar Restaurante', null))
     );
  }
  delete(restaurante: Restaurante | string): Observable<string> {
   const id = typeof restaurante === 'string' ? restaurante : restaurante.nit;
   return this.http.delete<string>(this.baseUrl + 'api/Restaurante/' + id)
     .pipe(
       tap(_ => this.handleErrorService.log('datos enviados')),
       catchError(this.handleErrorService.handleError<string>('Eliminar Restaurante', null))
     );
 }
  /** PUT: update the profesor on the server */
  put(restaurante: Restaurante): Observable<any> {
    const url = `${this.baseUrl}api/Cliente/${restaurante.nit}`;
    return this.http.put(url, restaurante, httpOptions)
      .pipe(
        tap(_ => this.handleErrorService.log('datos enviados')),
        catchError(this.handleErrorService.handleError<any>('Editar Restaurante'))
      );
  }

 getId(nit: string): Observable<Restaurante> {
   const url = `${this.baseUrl + 'api/Restaurante'}/${nit}`;
   return this.http.get<Restaurante>(url, httpOptions)
     .pipe(
       tap(_ => this.handleErrorService.log('datos enviados')),
       catchError(this.handleErrorService.handleError<Restaurante>('Buscar Restaurante', null))
     );
 }


}
