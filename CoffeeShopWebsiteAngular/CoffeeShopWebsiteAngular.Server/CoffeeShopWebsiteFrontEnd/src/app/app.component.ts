import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';
import { EmailServiceService } from './services/email-service.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit{
  title = 'CoffeeShopWebsiteFrontEnd';
  constructor(private authService: AuthService, private emailService: EmailServiceService) { }
  ngOnInit() {
    this.checkLogin();
  }
  checkLogin() {
    if (this.authService.getToken() != null) {
    //  console.log("Token is not null")
    //  console.log("Token is: ", this.authService.getToken())
      return true;
    }
    else {
     // console.log("Token is null")
      return false;
    }
  }
  checkLogout() {
    this.authService.logout();
    this.emailService.deleteEmail();
  }
}
