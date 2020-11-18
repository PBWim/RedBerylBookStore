import { Injectable, Inject } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class BooksService {
  myAppUrl: string = "";

  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }

  getBooks(searchText): Observable<any> {
    const headers = new Headers({
      'Content-Type': 'application/json',
    })
    return this.http.get(this.myAppUrl + 'api/Books/GetBooks?search=' + searchText, { headers: headers });
  }

  getBooksByAuthor(auth_token, userId): Observable<any> {
    const headers = new Headers({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${auth_token}`
    })
    return this.http.get(this.myAppUrl + 'api/Books/GetBooksByAuthor?userId=' + userId, { headers: headers });
  }

  createBook(auth_token, bookObj, userId): Observable<any> {
    const headers = new Headers({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${auth_token}`
    })
    return this.http.post(this.myAppUrl + 'api/Books/CreateBook',
      {
        title: bookObj.title,
        description: bookObj.description,
        price: bookObj.price,
        isActive: true,
        userId: userId
      }, { headers: headers });
  }
}
