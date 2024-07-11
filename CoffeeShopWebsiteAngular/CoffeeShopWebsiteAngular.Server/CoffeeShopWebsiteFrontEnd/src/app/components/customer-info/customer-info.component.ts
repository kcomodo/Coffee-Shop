import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer-info',
  templateUrl: './customer-info.component.html',
  styleUrl: './customer-info.component.css'
})
export class CustomerInfoComponent {
  FirstName: string = '';
  LastName: string = '';
  Email: string = 'QuangHo@gmail.com';
  Password: string = '';
  PhoneNumber: string = '';
  constructor(private authService: AuthService, private router: Router) {

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
