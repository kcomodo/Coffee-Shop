import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  customer: any;

  constructor(private customerService: AuthService) { }

  ngOnInit(): void {
    this.getCustomer('QuangHo@gmail.com'); // Replace with actual email
  }

  getCustomer(email: string): void {
    this.customerService.getCustomerByEmail(email).subscribe(
      (data) => {
        this.customer = data;
      },
      (error) => {
        console.error('Error fetching customer:', error);
      }
    );
  }
}
