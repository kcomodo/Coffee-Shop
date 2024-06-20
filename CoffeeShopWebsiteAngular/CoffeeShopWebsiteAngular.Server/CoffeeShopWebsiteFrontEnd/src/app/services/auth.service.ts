import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://localhost:7059';
  constructor(private http: HttpClient) { }

  validateLogin(email: string, password: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/ValidateLogin`, { email, password });
  }
}
