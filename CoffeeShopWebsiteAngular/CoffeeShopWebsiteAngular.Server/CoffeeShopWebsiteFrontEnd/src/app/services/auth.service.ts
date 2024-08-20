import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { CookieService } from 'ngx-cookie-service';
import { Token } from '@angular/compiler';
import { map } from 'rxjs/operators';
import { response } from 'express';
import { HttpHeaders } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
@Injectable({
  providedIn: 'root'
})
export class AuthService implements OnInit{
  //default url for the api which is swagger
  private token: string | null = null;
  private isAuthenticated = false;
  private baseUrl = 'https://localhost:7059';
  private tokenSaved = 'tokenSaved';
  constructor(private http: HttpClient, private cookieService: CookieService) { }
  ngOnInit() {
    if(this.getToken() != null){
      this.isAuthenticated = true;
     // console.log("the token is true, will stay on customer info page: ", this.isAuthenticated);
    }
  }
  //Call the controller methods from asp.net
  //Put a body in here because angular does not like having less than 2 parameters
  //Now we connect the api return using the pipe method
  //Pipe is a function that takes an observable as input and returns another observable
  //Tap is a function that performs side effects on the observable sequence
    //Pipe chains the the tap operator with the returned value from the http post method
    //Tap takes the response and checks if the response is true or false
    //Angular uses 3 equal signs, weird.
  //https://localhost:7059/ValidateLogin?email=testing%40gmail.com&password=testing12345
  validateLogin(email: string, password: string): Observable<boolean> {
    const body = { email: email, password: password };
    //Send the email and password to the api to receive a token if the login is valid
    const url = `${this.baseUrl}/CustomerValidateLogin?email=${encodeURIComponent(email)}&password=${encodeURIComponent(password)}`;
     return this.http.post<{ token: string }>(`${this.baseUrl}/CustomerValidateLogin?email=${email}&password=${password}`, body)
    //return this.http.post<{ token: string }>(`${this.baseUrl}/CustomerValidateLogin`, body)
    //return this.http.post<{ token: string }>(url, null)
      .pipe(
        tap(response => {
          if (response.token) {
            this.token = response.token;
            this.isAuthenticated = true; // Set authentication status based on response
          //  console.log("isLoggedin received: ", this.isAuthenticated);
           // console.log("Token received and saved: ", this.token);
            this.cookieService.set(this.tokenSaved, this.token, { path: '/' });
          }
         else if (this.getToken() != null) {
            this.isAuthenticated = true;
          }
          else {
            this.isAuthenticated = false;
          //  console.log(response.token);
          //  console.log("isLoggedin failed: ", this.isAuthenticated);
          }

        }),
        
        map(response => !!response.token) // Transform response to a boolean


        /*
        Method is called -> Pass in parameters -> Value gets returned -> Connect value using pipe ->
        Tap will check if the response is true or false -> Use map to transform the response to a token ->
        if the token was received, then the authentication will be allowed -> Once that's done, store the token into a cookie storage
        */


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
    //grab the token, the token is stored inside the cookie
    const token = this.getToken();
    //every request needs a header from the token
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });
    return this.http.get<any>(`${this.baseUrl}/GetCustomerByEmail?email=${email}`, body);
  }
  //https://localhost:7059/GetCustomerIdUsingEmail?email=QuangHo%40gmail.com
  GetCustomerId(email: string): Observable<any> {
    const body = {};
    //grab the token, the token is stored inside the cookie
    const token = this.getToken();
  //  console.log("GetCusttomerId token grabbed: ", token);
    //every request needs a header from the token
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`
    });
    return this.http.get<any>(`${this.baseUrl}/GetCustomerByEmail?email=${email}`, { headers });
  }

  //https://localhost:7059/UpdateCustomer?firstname=UpdatedName&lastname=UpdatedLast&email=JohnDoe%40gmail.com&phone=00001234&password=55532
  UpdateCustomerInfo(updatedInfo: any): Observable<any> {
    const body = {};
    //Grab the model that was just called, (updatedInfo), and place it into the url
    return this.http.put<any>(`${this.baseUrl}/UpdateCustomer?firstname=${updatedInfo.first_name}&lastname=${updatedInfo.last_name}&email=${updatedInfo.customer_email}&phone=${updatedInfo.phone_number}&password=${updatedInfo.customer_password}`, body);
  }
  //created a method to check if the user is logged in
  isLoggedIn(): boolean {
  //  console.log("isLoggedin received: ", this.isAuthenticated);
    return this.isAuthenticated;
  }
  //created a method to log out the user
  
  logout(): void {
    //Make everything false and remove the token
    this.isAuthenticated = false;
    this.token = null;
    this.cookieService.delete(this.tokenSaved, '/'); 
  //  console.log('Logged out, token removed');

  }

  getToken(): string | null {
    //grab the token from the cookie service and then return it to be stored
    //cookieService is a library that allows us to store the token
    return this.cookieService.get(this.tokenSaved) || null;
  }
}
