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

  constructor(private authService: AuthService, private tokenStorage: TokenStorageService,
    private router: Router) { }

  ngOnInit() {
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
        this.router.navigate(['/']) 
      },
      err => {
        this.errorMessage = err.error.message;
        this.isLoginFailed = true;
      }
    );
  }
}
