import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { TokenStorageService } from '../services/token-storage.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form: any = {};
  isLoggedIn = false;
  isLoginFailed = false;
  errorMessage = '';
  role: '';
  name: '';

  constructor(private authService: AuthService, private tokenStorage: TokenStorageService,
    private router: Router) { }

  ngOnInit() {
    if (this.tokenStorage.getToken()) {
      var user = this.tokenStorage.getUser();
      this.isLoggedIn = true;
      this.role = user.role;
      this.name = user.firstName;
    }
  }

  onSubmit(): void {
    this.authService.login(this.form).subscribe(
      data => {
        var result = JSON.parse(data._body);
        var resultData = result.result.data;
        this.tokenStorage.saveToken(resultData.accessToken);
        this.tokenStorage.saveUser(resultData.loggedUser);

        this.isLoginFailed = false;
        this.isLoggedIn = true;
        this.role = resultData.loggedUser.role;
        this.name = resultData.loggedUser.firstName;
        this.router.navigate(['/']) 
      },
      err => {
        this.errorMessage = err.error.message;
        this.isLoginFailed = true;
      }
    );
  }
}
