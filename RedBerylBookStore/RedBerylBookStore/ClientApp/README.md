# RedBerylBookStore

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 6.0.0.

## Development server

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).



--------------------------------

https://www.c-sharpcorner.com/article/learn-angular-8-step-by-step-in-10-days-day-1/
* e2e - This folder is for an end to end testing purposes. It contains the configuration 
files related to performing the unit test of the projects.
* node_modules - This folder contains the downloaded packages as per the configuration.
* src - This folder contains the actual source code. It contains 3 subfolders as – 
1. app - App folder contains the Angular project-related files like components, HTML files, etc
2. assets - Assets folder contains any static files like images, stylesheets, 
custom javascript library files (if any required), etc.
3. environments - Environments folder contains the environment-related files which are required 
during deployment or build of the projects.


--------------------------------

https://www.c-sharpcorner.com/article/learn-angular-8-step-by-step-in-10-days-component-day-2/
Life Cycle of a Component
In Angular, every component has a life-cycle, a number of different stages it goes through 
from initialization to destruction. Every stage is called a life cycle hook event.
1. ngOnChanges - This event executes every time a value of an input control within the 
component has been changed. This event activates first when the value of a bound 
property has been changed.
2. ngOnInit - This event executed at the time of Component initialization. 
This event is called only once, just after the ngOnChanges() events. 
This event is mainly used to initialize data in a component.
3. ngDoCheck - This event is executed every time when the input properties of a 
component are checked. We can use this life cycle method to implement the checking on 
the input values as per our own logic check.
4. ngAfterContentInit - This lifecycle method is executed when Angular performs any 
content projection within the component views. This method executes only once when all the 
bindings of the component need to be checked for the first time. This event executes just 
after the ngDoCheck() method.
5. ngAfterContentChecked - This life cycle hook method executes every time the content of the 
component has been checked by the change detection mechanism of Angular. This method is called 
after the ngAfterContentInit() method. This method is can also be executed on every execution 
of ngDoCheck() event.
6. ngAfterViewInit - This life cycle method executes when the component completes the rendering 
of its view full. This life cycle method is used to initialize the component’s view and 
child views. It is called only once, after ngAfterContentChecked(). This lifecycle hook method 
only applies to components.
7. ngAfterViewChecked - This method is always executed after the ngAfterViewInit() method. 
Basically, this life cycle method is executed when the change detection algorithm of the 
angular component occurs. This method automatically executed every execution time of the 
ngAfterContentChecked().
8. ngOnDestroy - This method will be executed when we want to destroy the Angular components. 
This method is very useful for unsubscribing the observables and detaching the event handlers 
to avoid memory leaks. It is called just before the instance of the component being destroyed. 
This method is called only once, just before the component is removed from the DOM. 


--------------------------------

https://www.c-sharpcorner.com/article/learn-angular-8-step-by-step-in-10-days-data-binding-day-3/
Different Types of Data Binding
1. Interpolation -  Interpolation uses the braces expression i.e. {{ }} to render the bound 
value to the component template. It can be a static string, numeric value, or an object of 
your data model. In Angular, we use it like this: {{firstName}}.
<div>   
    <span>User Name : {{userName}}</span>      
</div>  

2. Property-Based Binding - Property binding used [] to send the data from the component to 
the HTML template. The most common way to use property binding is to assign any property 
of the HTML element tag into the [] with the component property value.
<input type="text" [value]="data.name"/>  

3. Event Binding
<div>  
    <input type="submit" value="Submit" (click)="fnSubmit()">  
</div> 

4. Two-Way Data Binding - Two-way binding is mainly used in the input type field or any form 
element where the user can provide input values from the browser or provides any value or 
changes any control value through the browser. On the other side, the same is automatically 
updated into the component variables and vice versa.
<input type="text" [(ngModel)] ="firstName"/>  

We use [] since it is actually a property binding, and parentheses are used for the event 
binding concept i.e. the notation of two-way data binding is [()]. 

EventBinding + PropertyBinding = [(ngModel)] = Two-Way Data Binding

ngModel performs both property binding and event binding. The below example demonstrates 
the implementation of two-way binding. In this example, we define a string variable 
called strName and assign that variable with a Textbox control. So, whenever we change any 
content in the textbox, the value of the variable will be changed automatically.
<div>  
    <input [(ngModel)]="strName" type="text"/>  
</div>

5. One-Way Binding - bind the data from the component to the view (DOM) or from 
view to the component. One-way data binding is unidirectional. You can only bind the 
data from component to the view or from view to the component. 
Eg: 
Interpolation, Property Binding, Attribute Binding, Class Binding, Style Binding
