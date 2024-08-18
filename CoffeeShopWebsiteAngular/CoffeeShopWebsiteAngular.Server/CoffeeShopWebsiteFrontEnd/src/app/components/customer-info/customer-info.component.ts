import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { EmailServiceService } from '../../services/email-service.service';
import { CookieService } from 'ngx-cookie-service'; // Example library
@Component({
  selector: 'app-customer-info',
  templateUrl: './customer-info.component.html',
  styleUrl: './customer-info.component.css'
})
export class CustomerInfoComponent implements OnInit {
  FirstName: string = '';
  LastName: string = '';
  Email: string = '';
  Password: string = '';
  PhoneNumber: string = '';
  isEditMode: boolean = false;

  constructor(
    private authService: AuthService,
    private router: Router,
    private emailService: EmailServiceService,
    private cookieService: CookieService
  ) { }
  ngOnInit(): void {
    // Perform actions with the token
    const testingtoken = this.authService.getToken();
   // console.log('Token retrieved at info page:', testingtoken);
    this.Email = this.emailService.getEmail();
   // console.log("Grabbing email:", this.Email);
    if (testingtoken) {
      // Use subscribe to store the info into response as a model or whatever is returned from the server
      this.Email = this.emailService.getEmail();
     // console.log("Grabbing email:", this.Email);
      this.authService.GetCustomerInfo(this.Email).subscribe((response) => {
      //  console.log("info: ",response);
        this.FirstName = response.first_name;
        this.LastName = response.last_name;
        this.Email = response.customer_email;
        this.Password = response.customer_password;
        this.PhoneNumber = response.phone_number;
      });
     // console.log("testing email on refresh",this.Email);
    }


  }
  toggleEditMode() {
    this.isEditMode = !this.isEditMode;
    //console.log("Edit clicked: ", this.isEditMode);
  }
}
  
  

