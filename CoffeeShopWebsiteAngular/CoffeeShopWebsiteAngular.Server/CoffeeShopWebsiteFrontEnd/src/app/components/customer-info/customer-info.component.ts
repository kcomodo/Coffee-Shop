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
      console.log(this.FirstName, this.LastName, this.Email, this.Password, this.PhoneNumber);
      this.FirstName = response.firstName;
      this.LastName = response.lastName;
      this.Email = response.email;
      this.Password = response.password;
      this.PhoneNumber = response.phone;
    });
  }

}
