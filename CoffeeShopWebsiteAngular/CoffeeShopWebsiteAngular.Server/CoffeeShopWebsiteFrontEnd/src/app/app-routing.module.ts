import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { HomeComponent } from './components/home/home.component';
import { CustomerInfoComponent } from './components/customer-info/customer-info.component';
import { AboutComponent } from './components/about/about.component';
import { ContactComponent } from './components/contact/contact.component';
import { MenuComponent } from './components/menu/menu.component';
import { EventsComponent } from './components/events/events.component';
import { AuthGuard } from './guards/auth.guard';

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
    component: CustomerInfoComponent,
    canActivate: [AuthGuard]
  },
  {
    path: 'about',
    component: AboutComponent
  },
  {
    path: 'contact',
    component: ContactComponent
  },
  {
    path: 'menu',
    component: MenuComponent,
  //  canActivate: [AuthGuard]
  },
  {
    path: 'events',
    component: EventsComponent,
   // canActivate: [AuthGuard]
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
