import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module'; // Import your routing module if separate
import { MatInputModule } from '@angular/material/input'; // Import Angular Material components

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component'; // Example of your application components

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MatInputModule // Import MatInputModule here
    // Other Angular Material modules can also be imported here if needed
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
