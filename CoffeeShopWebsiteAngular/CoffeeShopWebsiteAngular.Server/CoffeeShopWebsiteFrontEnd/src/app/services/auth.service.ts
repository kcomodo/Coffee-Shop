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
}
