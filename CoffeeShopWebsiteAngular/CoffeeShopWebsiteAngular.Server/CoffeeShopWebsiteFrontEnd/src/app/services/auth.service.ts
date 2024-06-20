import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5097/GetCustomerByEmail';
  constructor(private http: HttpClient) { }

  getCustomerByEmail(email: string): Observable<any> {
    const params = new HttpParams().set('email', email);
    return this.http.get<any>(this.apiUrl, { params });
  }
}
