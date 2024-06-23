import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  //default url for the api which is swagger
  private baseUrl = 'https://localhost:7059';
  constructor(private http: HttpClient) { }
  //Call the controller methods from asp.net
  //Put a body in here because angular does not like having less than 2 parameters
  //https://localhost:7059/ValidateLogin?email=testing%40gmail.com&password=testing12345
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
