import { Component } from '@angular/core';

// https://www.c-sharpcorner.com/article/learn-angular-8-step-by-step-in-10-days-component-day-2/
// In TypeScript, a component is basically a TypeScript
// class decorated with an @Component() decorator

// So in Angular, when we want to create any new component,
// we need to use the @Component decorator.
@Component({
  // Selector tag on index.html
  selector: 'app-root', 

  // This property always accepts the HTML file name with its related file path
  templateUrl: './app.component.html',

  // we can pass the HTML tags or code directly as inline code (inline template)
  //template: "",

  // To provide an inline style, we need to use styles, and to provide an
  // external file path or URL, we need to use styleUrls
  styleUrls: ['./app.component.css'],

  // we need to use or inject different types of custom services within the component
  // to implement the business logic for the component.
  // To use any user-defined service within the component, we need to provide the service
  // instance within the provider
  //providers: []
})

 // this is a Basic Component
export class AppComponent {
  title = 'app';
}
