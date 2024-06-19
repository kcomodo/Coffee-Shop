import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../services/customer.service';
import { CustomerModel } from '../models/customer.model.model';
@Component({
  selector: 'app-customer',
  standalone: true,
  imports: [],
  templateUrl: './customer.component.html',
  styleUrl: './customer.component.css'
})
export class CustomerComponent implements OnInit {
  customer: CustomerModel | undefined;

  constructor(private customerService: CustomerService) { }

  ngOnInit(): void {
    this.getCustomer('QuangHo@gmail.com');
  }

  getCustomer(email: string): void {
    this.customerService.getCustomerByEmail(email).subscribe(
      (data) => this.customer = data,
      (error) => console.error(error)
    );
  }
}
