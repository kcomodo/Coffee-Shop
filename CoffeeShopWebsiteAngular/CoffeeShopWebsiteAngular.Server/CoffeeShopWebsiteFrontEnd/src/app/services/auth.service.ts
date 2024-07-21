import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  //default url for the api which is swagger
  private isAuthenticated = false;
  private baseUrl = 'https://localhost:7059';
  constructor(private http: HttpClient) { }
  //Call the controller methods from asp.net
  //Put a body in here because angular does not like having less than 2 parameters
      //Now we connect the api return using the pipe method
    //Pipe is a function that takes an observable as input and returns another observable
    //Tap is a function that performs side effects on the observable sequence
    //Pipe chains the the tap operator with the returned value from the http post method
    //Tap takes the response and checks if the response is true or false
    //Angular uses 3 equal signs, weird.
  //https://localhost:7059/ValidateLogin?email=testing%40gmail.com&password=testing12345
  /*
  validateLogin(email: string, password: string):Observable<any>{
    const body = { email: email, password: password };

    return this.http.post<any>(`${this.baseUrl}/CustomerValidateLogin?email=${email}&password=${password}`, body).pipe(tap(response => {
      if (response == true) {
        this.isAuthenticated = true;
        console.log("isLoggedin recieved: ", this.isAuthenticated);
      }
      else {
        this.isAuthenticated = false;
        console.log("isLoggedin recieved: ", this.isAuthenticated);
      }

    }));
    
  }
  */
  validateLogin(email: string, password: string): Observable<boolean> {
    const body = { email: email, password: password };

    return this.http.post<any>(`${this.baseUrl}/CustomerValidateLogin?email=${email}&password=${password}`, body)
      .pipe(
        tap(response => {
          this.isAuthenticated = response; // Set authentication status based on response
          console.log("isLoggedin received: ", this.isAuthenticated);
        })
      );
  }
  //https://localhost:7059/RegisterCustomer?firstname=testing&lastname=testing12345&email=testing%40gmail.com&phone=123456789&password=testing12345
  registerUser(firstname: string, lastname: string, email: string, phone: string, password: string):Observable<any>{
    const body = { firstname: firstname, lastname: lastname, email: email, phone: phone, password: password };
    return this.http.post<any>(`${this.baseUrl}/RegisterCustomer?firstname=${firstname}&lastname=${lastname}&email=${email}&phone=${phone}&password=${password}`, body);
  }

  //https://localhost:7059/GetCustomerByEmail?email=QuangHo%40gmail.com
  GetCustomerInfo(email: string): Observable<any> {
    const body = {};
    return this.http.get<any>(`${this.baseUrl}/GetCustomerByEmail?email=${email}`, body);
  }
  //https://localhost:7059/GetCustomerIdUsingEmail?email=QuangHo%40gmail.com
  GetCustomerId(email: string): Observable<any> {
    const body = {};
    return this.http.get<any>(`${this.baseUrl}/GetCustomerIdUsingEmail?email=${email}`, body);
  }
  //created a method to check if the user is logged in
  isLoggedIn(): boolean {
    console.log("isLoggedin received: ", this.isAuthenticated);
    return this.isAuthenticated;
  }
  //created a method to log out the user
  logout(): void {
    this.isAuthenticated = false;
    console.log("isLoggedin received: ", this.isAuthenticated);
    localStorage.removeItem('token');
  }
}
