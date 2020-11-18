import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })

export class AuthService {
  myAppUrl: string = "";

  constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
    this.myAppUrl = baseUrl;
  }

  login(credentials): Observable<any> {
    return this.http.post(this.myAppUrl + 'api/Account/Login',
      {
        email: credentials.email,
        password: credentials.password
      }
    );
  }

  register(user): Observable<any> {
    return this.http.post(this.myAppUrl + 'api/Account/Register',
      {
        email: user.email,
        password: user.password,
        firstName: user.firstName,
        lastName: user.lastName,
        role: "Author",
        isActive: true
      }
    );
  }
}
