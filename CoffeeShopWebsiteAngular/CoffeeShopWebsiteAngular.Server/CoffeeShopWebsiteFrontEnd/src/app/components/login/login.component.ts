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


  emailFormControl = new FormControl('', [Validators.required, Validators.email]);
  passwordFormControl = new FormControl('', [Validators.required]);

  constructor(private authService: AuthService, private router: Router, private emailService: EmailServiceService) { }
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
        console.error('Login failed', error);
        // Handle login error, e.g., display error message


      }
    );
  }
}
