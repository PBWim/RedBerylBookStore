import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

// https://www.c-sharpcorner.com/article/learn-angular-8-step-by-step-in-10-days-data-binding-day-3/
// when we use ngModel or two-way data binding in our components,
// then we need to include FormsModule of Angular in our own defined app module file
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
// https://www.c-sharpcorner.com/article/learn-angular-8-step-by-step-in-10-days-day-1/
// In every Angular application, at least one angular module file is required.
// An Angular application may contain more than one Angular module.
// Angular modules is a process or system to assemble multiple angular elements,
// like components, directives, pipes, service, etc.so that these Angular elements can be
// combined in such a way that all elements can be related with each other and ultimately
// create an application.

// In Angular, @NgModule decorator is used to defining the Angular module class.

// @NgModule always takes a metadata object, which tells Angular how to
// compile and launch the application in the browser.
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { AuthorsComponent } from './authors/authors.component';
import { BooksComponent } from './books/books.component';
import { NewBookComponent } from './new-book/new-book.component';
import { ProfileComponent } from './profile/profile.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    RegisterComponent,
    AuthorsComponent,
    BooksComponent,
    NewBookComponent,
    ProfileComponent
  ],
  imports: [
    // BrowserModule class is responsible for running the application in the browser
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    HttpModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'view-authors', component: AuthorsComponent },
      { path: 'view-books', component: BooksComponent },
      { path: 'new-book', component: NewBookComponent },
      { path: 'profile', component: ProfileComponent },
    ])
  ],
  providers: [],
  // we need to mention one Angular component as a root component for the Angular module
  // This component is always known as a bootstrap component.
  // So, one Angular module can contain hundreds of components.But out of those components,
  // one component needs to be a root or bootstrap component that will be executed
  // first when the Angular module will be bootstrapped in the browser
  bootstrap: [AppComponent]
})
export class AppModule { }
