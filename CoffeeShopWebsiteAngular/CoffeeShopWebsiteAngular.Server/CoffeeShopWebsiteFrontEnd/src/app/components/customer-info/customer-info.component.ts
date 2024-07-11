import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { EmailServiceService } from '../../services/email-service.service'; 
@Component({
  selector: 'app-customer-info',
  templateUrl: './customer-info.component.html',
  styleUrl: './customer-info.component.css'
})
export class CustomerInfoComponent {
  FirstName: string = '';
  LastName: string = '';
  Email: string = '';
  Password: string = '';
  PhoneNumber: string = '';
  constructor(private authService: AuthService, private router: Router, private emailService: EmailServiceService) {
    //use subscribe to store the info into response as a model or whatever is returned from the server
    this.Email = this.emailService.getEmail();
    console.log("Grabbing email:",this.Email)
    this.authService.GetCustomerInfo(this.Email).subscribe((response) => {
      console.log(response);
      this.FirstName = response.first_name;
      this.LastName = response.last_name
      this.Email = response.customer_email;
      this.Password = response.customer_password;
      this.PhoneNumber = response.phone_number;
  
    });
  }

}
