import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { HomeComponent } from './components/home/home.component';
import { CustomerInfoComponent } from './components/customer-info/customer-info.component';
//this is the router module, it is used to define the routes of the application
//the blank path will redirect to the home component when the application is started
const routes: Routes = [
  {
    path: 'login',
    component: LoginComponent
  },
  {
    path: 'register',
    component:RegisterComponent
  },
  {
    path: 'home',
    component:HomeComponent
  },
  {
    path: 'customer-info',
    component: CustomerInfoComponent
  },
  {
    path: '', redirectTo: 'home', pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
