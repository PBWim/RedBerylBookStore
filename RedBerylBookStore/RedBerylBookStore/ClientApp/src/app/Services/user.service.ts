import { Injectable, Inject } from '@angular/core';
import { Http, Headers, Response } from '@angular/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class UserService {
  myAppUrl: string = "";

  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }

  getAuthors(auth_token): Observable<any> {
    const headers = new Headers({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${auth_token}`
    })
    return this.http.get(this.myAppUrl + 'api/User/GetAuthors', { headers: headers });
  }

  activateAuthor(auth_token, userId): Observable<any> {
    const headers = new Headers({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${auth_token}`
    })
    return this.http.get(this.myAppUrl + 'api/User/ActivateAuthor?userId=' + userId, { headers: headers });
  }

  deactivateAuthor(auth_token, userId): Observable<any> {
    const headers = new Headers({
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${auth_token}`
    })
    return this.http.get(this.myAppUrl + 'api/User/DeactivateAuthor?userId=' + userId, { headers: headers });
  }
}
