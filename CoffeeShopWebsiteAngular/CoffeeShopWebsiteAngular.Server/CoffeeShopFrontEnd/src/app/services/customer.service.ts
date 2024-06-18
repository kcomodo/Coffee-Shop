import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CustomerModel } from '../models/customer.model.model'; // Ensure this file exists
@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private apiUrl = 'https://localhost:5001/api/customer'; // Adjust the URL as needed

  constructor(private http: HttpClient) { }

  getCustomerByEmail(email: string): Observable<CustomerModel> {
    return this.http.get<CustomerModel>(`${this.apiUrl}/GetCustomerByEmail`, { params: { email } });
  }
}
