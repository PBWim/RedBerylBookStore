import { Component, OnInit } from '@angular/core';
import { TokenStorageService } from '../services/token-storage.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit{
  role: string;
  name: '';

  constructor(private tokenStorage: TokenStorageService) { }

  ngOnInit() {
    if (this.tokenStorage.getToken()) {
      var user = this.tokenStorage.getUser();
      this.name = user.firstName;
      this.role = user.role == 1 ? 'Administrator' : 'Author';
    }
  }

  isLoggedIn(): boolean {
    return this.tokenStorage.getToken() == null ? false : true;
  }
}
