import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Item } from "../books/books.model"
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class BooksserviceService {

  constructor(private http: HttpClient) { 
  }
  configUrl: string ="http://localhost:5059/api/Books/GetBooks";

  getBooks(): Observable<Item[]>{
    return this.http.get<Item[]>(this.configUrl);
  }
}
