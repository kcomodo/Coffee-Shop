import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { FormControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { EmailServiceService } from '../../services/email-service.service';
import { authGuard } from '../../guards/auth.guard';
import { JwtModule } from '@auth0/angular-jwt';
import { Token } from '@angular/compiler';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css',
})
export class LoginComponent {
  email: string = '';
  password: string = '';
  errorMessage: string = '';


  emailFormControl = new FormControl('', [Validators.required, Validators.email]);
  passwordFormControl = new FormControl('', [Validators.required]);

  constructor(private authService: AuthService, private router: Router, private emailService: EmailServiceService) { }
  //When onLogin is called, it will grab the email and password and send it to the validateLogin method in the auth service
  //Response will be the answered recieved from the api
  //Once the login is valid, we will use the email to grab the customer id, this is just for testing
  //We will also save the email by calling the email service
  onLogin(): void {
   // console.log(this.email, this.password);
    this.authService.validateLogin(this.email, this.password).subscribe(
      (response) => {
       // console.log(response);
       // console.log(this.email, this.password);
        // Handle successful login, e.g., redirect to dashboard
        if (response == true) {
          
          this.authService.GetCustomerId(this.email).subscribe(
            
            userId => {
            //  console.log("userid", userId);
              
            });

          this.emailService.setEmail(this.email);
         // console.log("Login successful, Email saved:", this.emailService.getEmail());
          this.router.navigate(['/home']);
        }
        
      },
      (error) => {
        //console.error('Login failed', error);
        // Handle login error, e.g., display error message
        this.errorMessage = 'Invalid Username or Password';


      }
    );
  }
}
