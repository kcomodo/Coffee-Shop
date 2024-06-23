import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl = 'https://localhost:7059';
  constructor(private http: HttpClient) { }

  validateLogin(email: string, password: string):Observable<any>{
    const body = { email: email, password: password };
    return this.http.post<any>(`${this.baseUrl}/ValidateLogin?email=${email}&password=${password}`, body);
  }
  //https://localhost:7059/RegisterCustomer?firstname=testing&lastname=testing12345&email=testing%40gmail.com&phone=123456789&password=testing12345
  registerUser(firstname: string, lastname: string, email: string, phone: string, password: string):Observable<any>{
    const body = { firstname: firstname, lastname: lastname, email: email, phone: phone, password: password };
    return this.http.post<any>(`${this.baseUrl}/RegisterCustomer?firstname=${firstname}&lastname=${lastname}&email=${email}&phone=${phone}&password=${password}`, body);
  }
}
