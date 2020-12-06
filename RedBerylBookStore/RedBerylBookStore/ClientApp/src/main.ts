// https://www.c-sharpcorner.com/article/learn-angular-8-step-by-step-in-10-days-day-1/
// The main.ts file acts as the main entry point of our Angular application.
// This file is responsible for the bootstrapper operation of our Angular modules.
// It contains some important statements related to the modules and some initial setup
// configurations like

// This option is used to disable Angular’s development mode and enable Productions mode.
// Disabling Development mode turns off assertions and other model - related checks
// within the framework.
import { enableProdMode } from '@angular/core';

// This option is required to bootstrap the Angular app n the browser
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';

// This option indicates which module acts as a root module in the applications
import { AppModule } from './app/app.module';

// This option stores the values of the different environment constants
import { environment } from './environments/environment';

export function getBaseUrl() {
  return document.getElementsByTagName('base')[0].href;
}

const providers = [
  { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] }
];

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic(providers).bootstrapModule(AppModule)
  .catch(err => console.log(err));
