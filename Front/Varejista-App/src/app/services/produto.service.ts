import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Produto } from '../models/Produto';

// @Injectable{
// // { providedIn: 'root'}
// }

export class  ProdutoService{
  baseURL = '';

  constructor (private http: HttpClient){}

  public getEventos(): Observable<Produto[]> {
    return this.http.get<Produto[]>(this.baseURL);
  }

  public getEventosByTema(nome: string): Observable<Produto[]> {
    return this.http.get<Produto[]>(`${this.baseURL}/${nome}/nome`);
  }

  public getEventoById(id: number): Observable<Produto> {
    return this.http.get<Produto>(`${this.baseURL}/${id}`);
  }
}
