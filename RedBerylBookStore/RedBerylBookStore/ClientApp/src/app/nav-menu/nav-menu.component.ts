import { Component } from '@angular/core';
import { TokenStorageService } from '../services/token-storage.service';
import { Router } from '@angular/router';

// This is a Nested Component inside the app.component (Parent - Child component)
@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  constructor(private tokenStorage: TokenStorageService, private router: Router) { }

  // In-Built Attribute Directive: ngClass
  isExpanded = false;

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  // In-Built Attribute Directive: ngIf
  isAdmin(): boolean {
    return this.tokenStorage.getToken() != null && this.tokenStorage.getUser().role == 1 ? true : false;
  }

  isAuthor(): boolean {
    return this.tokenStorage.getToken() != null && this.tokenStorage.getUser().role == 2 ? true : false;
  }

  isLoggedIn(): boolean {
    return this.tokenStorage.getToken() == null ? false : true;
  }

  logout() {
    this.tokenStorage.signOut();
    this.router.navigate(['/']) 
  }
}
